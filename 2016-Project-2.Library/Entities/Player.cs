using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Entities
{
    public class Player : Entity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<Character> Characters { get; set; }
        public Character CharacterActive { get; set; }

        public Player(string username)
        {
            Id = Guid.NewGuid();
            Username = username;
            Characters = new List<Character>();
        }

        public Player()
        {
            Characters = new List<Character>();
        }

    }
}
