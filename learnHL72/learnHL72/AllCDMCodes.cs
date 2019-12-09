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
        public List<CDMCode> CDMCodes = new List<CDMCode>();
        private string[] allCDMCodes;
        private List<string> segments = new List<string>();

        public AllCDMCodes(string[] allCDM)
        {
            allCDMCodes = allCDM;

            foreach (string code in allCDM)
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
        }

        public List<string> SegmentsInCDM()
        {
            foreach (string code in allCDMCodes)
            {
                string[] tuple = code.Split('\t').ToArray();

                if (!segments.Contains(tuple[0]))
                    {
                    segments.Add(tuple[0]);
                    }
            }
            return segments;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)CDMCodes).GetEnumerator();
        }
    }
}

