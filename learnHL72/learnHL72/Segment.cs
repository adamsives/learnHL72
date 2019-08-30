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

        public Segment(string segmentText)
        {
            string[] ss = segmentText.Split('|');
            foreach (string s in ss)
            {
                Field f = new Field(s);
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
