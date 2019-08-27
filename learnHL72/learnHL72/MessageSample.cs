using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class MessageSample : System.Collections.IEnumerable
    {
        public List<HL7Message> HL7Messages { get; set; }

        public MessageSample(string messageSampleText)
        {
            string[] ss = messageSampleText.Split((char)28);
            foreach (string s in ss)
            {
                HL7Message h = new HL7Message(s);
                HL7Messages.Add(h);
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}