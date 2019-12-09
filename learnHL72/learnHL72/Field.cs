using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class Field : System.Collections.IEnumerable
    {
        public string Name { get; set; }
        public List<SubField> SubFields = new List<SubField>();
        public string value;
        public FieldSepandEncodingChars fsc;

        public Field(string fieldText, FieldSepandEncodingChars fc)
        {
            if (fieldText.Contains(fc.fieldRepeatSeparator))
            {
                string[] ss = fieldText.Split(fc.fieldRepeatSeparator);
                foreach (string s in ss)
                {
                    SubField f = new SubField(s, fc);
                    SubFields.Add(f);
                }
            }
            else {
                value = fieldText;
            }

            fsc = fc;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubFields).GetEnumerator();
        }
    }
}
