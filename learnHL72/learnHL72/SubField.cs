using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class SubField
    {
        public string Name { get; set; }
        public List<SubSubField> SubSubFields = new List<SubSubField>();
        public string subfieldValue;

        public SubField(string subFieldText)
        {
            if (subFieldText.Contains("^"))
            {
                string[] ss = subFieldText.Split('~');
                foreach (string s in ss)
                {
                    SubSubField f = new SubSubField(s);
                    SubSubFields?.Add(f);
                }
            }
            else if (subFieldText != null) {
                SubSubField f = new SubSubField(subFieldText);
                SubSubFields?.Add(f);
                subfieldValue = subFieldText;
            }
        }
    }
}
