using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class Segment
    {
        public string Name { get; set; }
        public List<Field> Fields = new List<Field>();
        //public List<Field> Fields = new List<Field>();
        public string segment;

        public Segment(string segmentText)
        {
            string[] ss = segmentText.Split('|');
            foreach (string s in ss)
            {
                Field f = new Field(s);
                Fields.Add(f);
            }

            segment = segmentText;
        }
    }
}
