using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.utils.enums
{
    public class LogLevels
    {
        [Serializable]
        public enum LogLevel
        {
            NONE = 0,
            DEBUG = 1,
            INFO = 2,
            WARNING = 3,
            ERROR = 4,
            ALL = 99
        }
    }
}
