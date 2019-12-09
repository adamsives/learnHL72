using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class Segment : System.Collections.IEnumerable
    {
        public string Name { get; set; }
        public List<Field> Fields = new List<Field>();
        public string value;
        private FieldSepandEncodingChars fsc;

        public Segment(string segmentText, FieldSepandEncodingChars fs)
        {
            string[] ss = segmentText.Split(fs.fieldSeparator);
            foreach (string s in ss)
            {
                Field f = new Field(s, fs);
                Fields.Add(f);
            }

            value = segmentText;
            fsc = fs;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Fields).GetEnumerator();
        }
    }
}
