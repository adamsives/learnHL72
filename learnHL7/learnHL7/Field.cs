﻿using System;
using System.Collections.Generic;
using System.Text;

namespace learnHL7
{
    public class Field
    {
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
    }
}
