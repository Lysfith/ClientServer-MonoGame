using _2016_Project_2.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Stats
{
    public class Stat
    {
        public EnumStat Type { get; private set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
    }
}
