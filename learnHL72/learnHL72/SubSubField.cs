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
        public List<string> SubSubFields { get; set; }

        public SubSubField(string subSubFieldText)
        {
            string[] ss = subSubFieldText.Split('&');
            foreach (string s in ss)
            {
                //SubSubFields.Add("debug");
            }
        }
    }
}
