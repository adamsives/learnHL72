using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace learnHL72
{
    class AllCDMCodes : System.Collections.IEnumerable
    {
        private static AllCDMCodes allCDMCodes = new AllCDMCodes();
        private List<CDMCode> CDMCodes = new List<CDMCode>();

        public AllCDMCodes()
        {
            //string[] CDMCodeLines = File.ReadLines(fileName).ToArray();
        }

        public List<string> SegmentsInCDM(string fileName)
        {
            List<string> segments = new List<string>();

            string [] cdmCodes = File.ReadAllLines(fileName);

            foreach (string line in cdmCodes)
            {
                string[] tuple = line.Split('\t').ToArray();

                if (!segments.Contains(tuple[0]))
                    {
                    segments.Add(tuple[0]);
                    }
            }
            return segments;
        }

        public List<CDMCode> AllCodesToBeMapped(string fileName)//--this returns all codes
        {
            List<CDMCode> CDMCodes = new List<CDMCode>();

            string[] cdmCodes = File.ReadAllLines(fileName);

            foreach (string code in cdmCodes)
            {
                CDMCode currentCDMCode = new CDMCode();
                string[] CDMCodeLineArray = code.Split('\t').ToArray();
                currentCDMCode.Segment = CDMCodeLineArray[0];
                currentCDMCode.Field = CDMCodeLineArray[1];
                currentCDMCode.Component = CDMCodeLineArray[2];
                currentCDMCode.CodeValue = CDMCodeLineArray[3];
                currentCDMCode.TextDescription = CDMCodeLineArray[4];
                CDMCodes.Add(currentCDMCode);
            }
            return CDMCodes;
        }

        public List<CDMCode> AllCodesToBeMapped(string fileName, string segmentType)
        {
            List<CDMCode> CDMCodes = new List<CDMCode>();

            string[] cdmCodes = File.ReadAllLines(fileName);

            foreach (string code in cdmCodes)
            {
                CDMCode currentCDMCode = new CDMCode();
                string[] CDMCodeLineArray = code.Split('\t').ToArray();
                //------------
                if(segmentType == CDMCodeLineArray[0]) { 
                    currentCDMCode.Segment = CDMCodeLineArray[0];
                    currentCDMCode.Field = CDMCodeLineArray[1];
                    currentCDMCode.Component = CDMCodeLineArray[2];
                    currentCDMCode.CodeValue = CDMCodeLineArray[3];
                    currentCDMCode.TextDescription = CDMCodeLineArray[4];
                    CDMCodes.Add(currentCDMCode);
                }
                //------------
            }
            return CDMCodes;
        }

        public List<CDMCode> AllCodesToBeMapped(string fileName, string segmentType, int field)
        {
            List<CDMCode> CDMCodes = new List<CDMCode>();

            string[] cdmCodes = File.ReadAllLines(fileName);

            foreach (string code in cdmCodes)
            {
                CDMCode currentCDMCode = new CDMCode();
                string[] CDMCodeLineArray = code.Split('\t').ToArray();

                if (segmentType == CDMCodeLineArray[0] && field.ToString() == CDMCodeLineArray[1])
                {
                    currentCDMCode.Segment = CDMCodeLineArray[0];
                    currentCDMCode.Field = CDMCodeLineArray[1];
                    currentCDMCode.Component = CDMCodeLineArray[2];
                    currentCDMCode.CodeValue = CDMCodeLineArray[3];
                    currentCDMCode.TextDescription = CDMCodeLineArray[4];
                    CDMCodes.Add(currentCDMCode);
                }
            }
            return CDMCodes;
        }

        public List<string> AllCodesToBeMapped(string fileName, string segmentType, int field, int component)
        {
            List<string> CDMCodes = new List<string>();

            string[] cdmCodes = File.ReadAllLines(fileName);

            foreach (string code in cdmCodes)
            {
                CDMCode currentCDMCode = new CDMCode();
                string[] CDMCodeLineArray = code.Split('\t').ToArray();

                if (segmentType == CDMCodeLineArray[0] && field.ToString() == CDMCodeLineArray[1] && component.ToString() == CDMCodeLineArray[2])
                {
                    CDMCodes.Add(CDMCodeLineArray[3].ToString());
                }
            }
            return CDMCodes;
        }

        /*public List<string> FieldsAndSegmentsToBeMapped(string fileName)
        {
            foreach (string CDMCodeLine in CDMCodeLines)
            {
                List<string> codeAdndFieldSet = new List<string>();
                string[] CDMCodeLineArray = CDMCodeLine.Split('\t').ToArray();
                if (!FieldsAndSegments.Contains((CDMCodeLineArray[0] + CDMCodeLineArray[1] + CDMCodeLineArray[2])))
                {
                    FieldsAndSegments.Add(CDMCodeLineArray[0] + CDMCodeLineArray[1] + CDMCodeLineArray[2]);

                }
            }
            return FieldsAndSegments;
        }*/

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)CDMCodes).GetEnumerator();
        }
    }
}

