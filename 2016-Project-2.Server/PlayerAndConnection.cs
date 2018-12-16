using _2016_Project_2.Library;
using _2016_Project_2.Library.Entities;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server
{
    class PlayerAndConnection
    {
        private static int _idCpt = 0;

        public int Id { get; set; }
        public Player Player { get; set; }
        public NetConnection Connection { get; set; }
        public float Latency { get; set; }

        public PlayerAndConnection(Player player, NetConnection connection)
        {
            Id = _idCpt;
            Player = player;
            Connection = connection;

            _idCpt++;
        }
    }
}
