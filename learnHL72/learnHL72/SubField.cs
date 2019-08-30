using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class SubField : System.Collections.IEnumerable
    {
        public string Name { get; set; }
        public List<SubSubField> SubSubFields = new List<SubSubField>();
        public string value;

        public SubField(string subFieldText)
        {
            if (subFieldText.Contains("^"))
            {
                string[] ss = subFieldText.Split('^');
                foreach (string s in ss)
                {
                    SubSubField f = new SubSubField(s);
                    SubSubFields.Add(f);
                }
            }
            else if (subFieldText != null) {
                value = subFieldText;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubSubFields).GetEnumerator();
        }
    }
}
