using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server.Managers
{
    public class ManagerPlayer
    {
        private static ManagerPlayer _instance;

        public static ManagerPlayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerPlayer();
                }
                return _instance;
            }
        }

        private Dictionary<long, PlayerAndConnection> _players;

        public ManagerPlayer()
        {
            _players = new Dictionary<long, PlayerAndConnection>();
        }

        internal Guid AddPlayer(NetConnection connection, string userName)
        {
            var player = CreatePlayer(connection, userName);
            _players.Add(connection.RemoteUniqueIdentifier, player);

            return player.Player.Id;
        }

        internal PlayerAndConnection GetPlayerByConnectionId(long remoteUniqueIdentifier)
        {
            if(_players.ContainsKey(remoteUniqueIdentifier))
            {
                return _players[remoteUniqueIdentifier];
            }

            return null;
        }

        internal PlayerAndConnection GetPlayerById(Guid id)
        {
            var player = _players.Select(x => x.Value).FirstOrDefault(x => x.Player.Id == id);

            return player;
        }

        internal Dictionary<long, PlayerAndConnection> GetPlayers()
        {
            return _players;
        }

        internal void Clear()
        {
            _players.Clear();
        }

        private PlayerAndConnection CreatePlayer(NetConnection connection, string userName)
        {
            var player = new Player
            {
                Username = userName
            };

#if DEBUG
            player.Characters.Add(new Character("Aerith", EnumCharacterModel.MODEL_1));
            player.Characters.Add(new Character("Nanaki", EnumCharacterModel.MODEL_6));
            player.Characters.Add(new Character("Vincent", EnumCharacterModel.MODEL_8));
            player.Characters.Add(new Character("Barett", EnumCharacterModel.MODEL_2));
            player.Characters.Add(new Character("Tifa", EnumCharacterModel.MODEL_7));
            player.Characters.Add(new Character("Youffie", EnumCharacterModel.MODEL_9));
#else

#endif

            var playerAndConnection = new PlayerAndConnection(player, connection);
            //players.Add(playerAndConnection);
            return playerAndConnection;
        }
    }
}
