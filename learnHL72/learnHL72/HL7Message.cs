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
        public char fieldSeparator;
        public char fieldRepeatSeparator;
        public char escapeCharacter;
        public char subfieldSeparator;
        public char subSubFieldSeparator;
        public string segmentName;
        private string segmentString;
        private string[] ss;

        public HL7Message(string messageText)
        {
            ss = messageText.Trim().Split('\r');

            foreach (string s in ss) {
                Segment seg = new Segment(s);
                Segments.Add(seg);
            }

            value = messageText.Trim();

            foreach (string s in ss)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    string segName = s.Substring(0, 3);
                    if (segName == "MSH")
                    {
                        fieldSeparator = s[3];// usually|
                        subfieldSeparator = s[4];//usually = ^
                        fieldRepeatSeparator = s[5];//usually = ~
                        escapeCharacter = s[6]; //usually \
                        subSubFieldSeparator = s[7]; //usually &
                        string[] MSHSeg = s.Split(fieldSeparator);
                        messageId = MSHSeg[9];
                    }
                }
            }
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
            Segment seg = new Segment(segmentString);

            return seg;
        }

        public IEnumerator GetEnumerator() => ((IEnumerable)Segments).GetEnumerator();
    }
}