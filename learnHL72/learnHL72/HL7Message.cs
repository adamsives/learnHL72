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
        public List<Segment> Segments { get; set; }

        public HL7Message(string messageText)
        {
            string[] ss = messageText.Split('\n');
            foreach (string s in ss) {
                Segment seg = new Segment(s);
                Segments.Add(seg);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}