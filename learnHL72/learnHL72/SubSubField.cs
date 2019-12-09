using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class SubSubField
    {
        public string Name { get; set; }
        public List<string> SubSubFields = new List<string>();
        public string value;
        public FieldSepandEncodingChars fsc;

        public SubSubField(string subSubFieldText, FieldSepandEncodingChars f)
        {
            if (subSubFieldText.Contains(f.subSubFieldSeparator))
            {
                string[] ss = subSubFieldText.Split(f.subSubFieldSeparator);
                foreach (string s in ss)
                {
                    SubSubFields.Add(s);
                }
            }
            else if (subSubFieldText != null)
            {
                value = subSubFieldText;
            }
        }
    }
}
