using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace learnHL72
{
    public class Field : System.Collections.IEnumerable
    {
        public string Name { get; set; }
        public List<SubField> SubFields = new List<SubField>();
        public string value;
        public FieldSepandEncodingChars fsc;
        private string fieldValue;

        public Field(string fieldText, FieldSepandEncodingChars fc)
        {//------test if this is a repeating field that is NOT MSH1
            if ((fieldText.Contains(fc.fieldRepeatSeparator)) && (fc.fieldSeparator.ToString() + fieldText != fc.allSpecialChars))
            {//create a subfield on the "~" delimiter
                    string[] ss = fieldText.Split(fc.fieldRepeatSeparator);//---split the "~" delimited string
                    foreach (string s in ss)
                    {
                        SubField f = new SubField(s, fc);
                        SubFields.Add(f);
                    }
            }
            else
            {
                if (fc.fieldSeparator.ToString() + fieldText == fc.allSpecialChars)
                {
                    fieldValue = fc.fieldSeparator.ToString() + fieldText;
                }
                else
                {
                    if (!fieldText.Contains(fc.subSubFieldSeparator))
                    {
                        fieldValue = fieldText;
                    }
                    else
                    {
                        //----test to find position of the '&'
                        int index = fieldText.IndexOf(fc.subSubFieldSeparator);
                        int len = fieldText.Length;
                        int i = 0;

                        while (i <= len)
                        {
                            // start+count must be a position within -str-.
                            if (fieldText.Substring(0, 1) == fc.escapeCharacter.ToString())
                            {
                                //this is an escaped subsubfield char
                            }
                            else {

                            }
                            index++;
                            i++;
                        }

                        SubSubField ss = new SubSubField(fieldText, fc);
                    }
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubFields).GetEnumerator();
        }
    }
}