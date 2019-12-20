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
            //---------check for escaped charachters here
            Escape e = new Escape(segmentText.Trim(), fs.fieldSeparator);
            string[] ss = segmentText.Trim().Split(fs.fieldSeparator);
            foreach (string s in ss)
            {
                Field f = new Field(e.escapedString, fs);
                Fields.Add(f);
            }

            value = segmentText;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Fields).GetEnumerator();
        }
    }
}
