using _2016_Project_2.Library.Effects;
using _2016_Project_2.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Skills
{
    public class Skill
    {
        public string Name { get; private set; }

        private List<Effect> _effects;

        public Skill(string name)
        {
            Name = name;
            _effects = new List<Effect>();
        } 

        public void AddEffect(Effect effect)
        {
            _effects.Add(effect);
        }

        public void Apply(Character source, Character target)
        {
            if (source == null || target == null)
            {
                throw new ArgumentNullException();
            }
            
        }
    }
}
