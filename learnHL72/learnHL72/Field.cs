using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class Field
    {
        public string Name { get; set; }
        public List<SubField> SubFields { get; set; }

        public Field(string fieldText)
        {
            string[] ss = fieldText.Split('|');
            foreach (string s in ss)
            {
                SubField f = new SubField(s);
                //SubFields.Add(f);
            }
        }
    }
}
