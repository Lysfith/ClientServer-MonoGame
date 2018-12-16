using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Effects
{
    public class DamageEffect : Effect
    {
        public DamageEffect(int amount)
            :base(EnumEffect.DAMAGE)
        {
            _action = Action;
            _amount = amount;
        } 

        public void Action(Character source, Character target)
        {
            
        }
    }
}
