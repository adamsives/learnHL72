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
        public FieldSepandEncodingChars fsc;

        public SubField(string subFieldText, FieldSepandEncodingChars fs)
        {
            if (subFieldText.Contains(fs.subfieldSeparator))
            {
                string[] ss = subFieldText.Split(fs.subfieldSeparator);
                foreach (string s in ss)
                {
                    SubSubField f = new SubSubField(s, fs);
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
