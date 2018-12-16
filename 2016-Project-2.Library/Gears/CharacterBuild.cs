using _2016_Project_2.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Gears
{
    [Serializable]
    public class CharacterBuild
    {
        public Dictionary<EnumGearSlot, Gear> _gears;

        public CharacterBuild()
        {
            _gears = new Dictionary<EnumGearSlot, Gear>();

            _gears.Add(EnumGearSlot.BELT, null);
            _gears.Add(EnumGearSlot.CHEST, null);
            _gears.Add(EnumGearSlot.FEET, null);
            _gears.Add(EnumGearSlot.HAND, null);
            _gears.Add(EnumGearSlot.HEAD, null);
            _gears.Add(EnumGearSlot.LEFT_HAND, null);
            _gears.Add(EnumGearSlot.LEGS, null);
            _gears.Add(EnumGearSlot.NECK, null);
            _gears.Add(EnumGearSlot.RIGHT_HAND, null);
            _gears.Add(EnumGearSlot.SHOULDERS, null);
            _gears.Add(EnumGearSlot.WRIST, null);
        }

        public Gear Equip(EnumGearSlot slot, Gear gear)
        {
            var currentGear = _gears[slot];

            _gears[slot] = gear;

            return currentGear;
        }
    }
}
