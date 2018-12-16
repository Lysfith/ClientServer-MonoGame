using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Effects
{
    public class Effect
    {
        public EnumEffect Type { get; private set; }

        protected Action<Character, Character> _action;

        protected double _duration;
        protected double _interval;
        protected int _amount;

        public Effect(EnumEffect type)
        {
            Type = type;
        }

        public void Apply(Character source, Character target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException();
            }

            _action(source, target);
        }
    }
}
