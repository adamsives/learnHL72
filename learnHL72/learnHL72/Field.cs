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
        public List<SubField> SubFields = new List<SubField>();
        public string fieldValue;
        public Field(string fieldText)
        {
            /*if (fieldText.Contains("~"))
            {
                string[] ss = fieldText.Split('~');
                foreach (string s in ss)
                {
                    SubField f = new SubField(s);
                    SubFields?.Add(f);
                }
            }
            else {
                SubField f = new SubField(fieldText);
                SubFields?.Add(f);
                fieldValue = fieldText;
            }*/

            fieldValue = fieldText;
        }
    }
}
