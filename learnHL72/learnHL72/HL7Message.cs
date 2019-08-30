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

        public HL7Message(string messageText)
        {
            string[] ss = messageText.Trim().Split('\r');
            foreach (string s in ss) {
                Segment seg = new Segment(s);
                Segments.Add(seg);
            }

            value = messageText.Trim();

            foreach (string s in ss)
            {
                if (s.Substring(0, 3) == "MSH")
                {
                    fieldSeparator = s[3];// usually|
                    subfieldSeparator = s[4];//usually = ^
                    fieldRepeatSeparator = s[5];//usually = ~
                    escapeCharacter = s[6]; //usually \
                    subSubFieldSeparator = s[7]; //usually &

                    string [] MSHSeg = s.Split(fieldSeparator);
                    messageId = MSHSeg[9];
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Segments).GetEnumerator();
        }
    }
}