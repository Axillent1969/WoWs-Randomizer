using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.utils
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Method | System.AttributeTargets.Property | System.AttributeTargets.ReturnValue)
]
    public class Exposed : System.Attribute
    {
        private bool exposed;

        public Exposed(bool isExposed)
        {
            this.exposed = isExposed;
        }
    }
}
