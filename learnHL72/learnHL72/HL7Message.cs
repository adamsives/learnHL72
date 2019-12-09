using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class HL7Message : System.Collections.IEnumerable
    {
        public List<Segment> Segments = new List<Segment>();
        public string messageId;
        public string value;
        public string segmentName;
        private string segmentString;
        public FieldSepandEncodingChars fsChars;
        private string[] ss;

        public HL7Message(string messageText)
        {
            ss = messageText.Trim().Split('\r');

            foreach (string s in ss) {

                if (s.Length > 0)
                {
                    if (s.Substring(0, 3) == "MSH")
                    {
                        fsChars = new FieldSepandEncodingChars(s.Substring(3, 5));
                    }

                    Segment seg = new Segment(s, fsChars);
                    Segments.Add(seg); 
                }
            }

            value = messageText.Trim();



        }
        //TODO: access segment by name
        private Segment GetSegment(string segName)
        {
           foreach (string s in ss)
            {
                if (segName == s.Substring(0, 3))
                {
                    string segmentString = s;
                }
            }
            Segment seg = new Segment(segmentString, fsChars);

            return seg;
        }

        public IEnumerator GetEnumerator() => ((IEnumerable)Segments).GetEnumerator();
    }
}