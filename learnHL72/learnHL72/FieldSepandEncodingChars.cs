using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnHL72
{
    public class FieldSepandEncodingChars
    {
        public char fieldSeparator;
        public char fieldRepeatSeparator;
        public char escapeCharacter;
        public char subfieldSeparator;
        public char subSubFieldSeparator;
        private char[] s;

        public FieldSepandEncodingChars(string f)
        {
            s = f.ToCharArray(0, 5);
            this.fieldSeparator = s[0];//---|
            this.fieldRepeatSeparator = s[2];//---~
            this.escapeCharacter = s[3];//---\
            this.subfieldSeparator = s[1];//---^
            this.subSubFieldSeparator = s[4];//---&
        }
    }
}
