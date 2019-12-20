using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    class Escape
    {
        public string escapedString;

        public Escape(string s, char separator) {

            if (s.Contains(f.escapeCharacter))
            {
                int x = s.IndexOf(f.escapeCharacter);
                do
                {
                    if (x != -1)
                    {
                        if (s.Substring(x + 1) == separator.ToString() || s.Substring(x + 1) == separator.ToString() || s.Substring(x + 1) == separator.ToString())
                        {
                            //--remove the escape character and return the string
                            s.Remove(x);
                            x = s.IndexOf(separator);
                        }
                    }
                } while (x <= s.Length);
            }

            escapedString = s;

        }
    }
}
