using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.objects.exceptions
{
    public class AllocatingException : Exception
    {
        public AllocatingException() {}

        public AllocatingException(string message) : base(message)   {   }

        public AllocatingException(string message, Exception inner) : base(message,inner) { }
    }
}
