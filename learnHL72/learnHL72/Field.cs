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
        public Field(string fieldText)
        {
            if (fieldText.Contains("~"))
            {
                string[] ss = fieldText.Split('~');
                foreach (string s in ss)
                {
                    SubField f = new SubField(s);
                    SubFields.Add(f);
                }
            }
            else {
                value = fieldText;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubFields).GetEnumerator();
        }
    }
}
