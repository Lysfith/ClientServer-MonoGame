using _2016_Project_2.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Gears
{
    [Serializable]
    public class Gear
    {
        public string Name { get; private set; }
        public EnumGearSlot Slot { get; private set; }

        public Gear(string name, EnumGearSlot slot)
        {
            Name = name;
            Slot = slot;
        }
    }
}
