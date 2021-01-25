using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWs_Randomizer.utils
{
    [Serializable]
    public class QueryReport
    {
        public bool useAllShips { get; set; }
        public bool useExclusionList { get; set; }
        public List<string> conditions { get; set; }
        public List<string> queries { get; set; }
        public List<string> selectedFields { get; set; }
        
        public List<string> unusedFields { get; set; }

        public QueryReport() { }

    }
}
