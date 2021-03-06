﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWs_Randomizer.utils.enums;

namespace WoWs_Randomizer.utils
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Method | System.AttributeTargets.Property | System.AttributeTargets.ReturnValue)
]
    public class Exposed : System.Attribute
    {
        private string name;

        public Exposed(string name = "")
        {
            this.name = name;
        }
        public string getName() { return this.name; }
    }
}
