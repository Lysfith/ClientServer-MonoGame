using _2016_Project_2.Library;
using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using _2016_Project_2.Server.Managers;
using Lidgren.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Server.Commands
{
//    class LoginCommand : ICommand
//    {
//        public PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection)
//        {
//            managerLogger.AddLogMessage("Server", "Login...");

//            playerAndConnection = CreatePlayer(inc);

                
//            var outmsg = server.NetServer.CreateMessage();
//            outmsg.Write((byte)PacketType.Login);

//            var str = JsonConvert.SerializeObject(playerAndConnection.Player);
//            outmsg.Write(str); 
//            //outmsg.Write(playerAndConnection.Player.Characters.Count);
//            //foreach (var character in playerAndConnection.Player.Characters)
//            //{
//            //    outmsg.WriteAllFields(character);
//            //}

//            managerLogger.AddLogMessage("Server", playerAndConnection.Player.Username + " logged");

//            //outmsg.Write(gameRoom.Players.Count);
//            //for (int n = 0; n < gameRoom.Players.Count; n++)
//            //{
//            //    var p = gameRoom.Players[n];
//            //    outmsg.Write(p.Player.Username);
//            //    outmsg.WriteAllProperties(p.Player.Position);
//            //}
//            server.NetServer.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
//            //var command = new PlayerPositionCommand();
//            //command.Run(managerLogger, server, inc, playerAndConnection, gameRoom);
//            //server.SendNewPlayerEvent(playerAndConnection.Player.Username, gameRoom.GameRoomId);

//            return playerAndConnection;
//        }

//        private PlayerAndConnection CreatePlayer(NetIncomingMessage inc)
//        {
//            var random = new Random();
//            var player = new Player
//            {
//                Username = inc.ReadString()
//            };

//#if DEBUG
//            player.Characters.Add(new Character("Aerith", EnumCharacterModel.MODEL_1));
//            player.Characters.Add(new Character("Nanaki", EnumCharacterModel.MODEL_6));
//            player.Characters.Add(new Character("Vincent", EnumCharacterModel.MODEL_8));
//            player.Characters.Add(new Character("Barett", EnumCharacterModel.MODEL_2));
//            player.Characters.Add(new Character("Tifa", EnumCharacterModel.MODEL_7));
//            player.Characters.Add(new Character("Youffie", EnumCharacterModel.MODEL_9));
//#else

//#endif

//            var playerAndConnection = new PlayerAndConnection(player, inc.SenderConnection);
//            //players.Add(playerAndConnection);
//            return playerAndConnection;
//        }

//    }
}
