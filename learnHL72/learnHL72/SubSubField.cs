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

        public SubSubField(string subSubFieldText)
        {
            if (subSubFieldText.Contains("&"))
            {
                string[] ss = subSubFieldText.Split('&');
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
