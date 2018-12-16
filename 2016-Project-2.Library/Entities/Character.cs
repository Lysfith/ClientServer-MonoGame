using _2016_Project_2.Library.Enums;
using _2016_Project_2.Library.Gears;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Entities
{
    public class Character
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public EnumCharacterModel Model { get; private set; }

        private CharacterBuild[] _builds;

        public EnumDirection Direction { get; set; }

        public Character(string name, EnumCharacterModel model)
        {
            Id = Guid.NewGuid();
            Name = name;
            Model = model;

            _builds = new CharacterBuild[3];
            Direction = EnumDirection.SOUTH;
        }

        public void CreateBuild(int index)
        {
            _builds[index] = new CharacterBuild();
        }
    }
}
