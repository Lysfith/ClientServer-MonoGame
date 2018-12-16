using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Entities
{
    public class Hub
    {
        public List<Player> Players { get; set; }

        public Hub()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public Player GetPlayer(string userName)
        {
            return Players.FirstOrDefault(x => x.Username == userName);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public List<Player> GetPlayers()
        {
            return new List<Player>(Players);
        }
    }
}
