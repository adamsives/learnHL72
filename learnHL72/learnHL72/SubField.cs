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
        public List<SubSubField> SubSubFields { get; set; }

        public SubField(string subFieldText)
        {
            string[] ss = subFieldText.Split('~');
            foreach (string s in ss)
            {
                SubSubField f = new SubSubField(s);
                //SubSubFields.Add(f);
            }
        }
    }
}
