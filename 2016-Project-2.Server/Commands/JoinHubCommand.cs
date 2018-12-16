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
    //class JoinHubCommand : ICommand
    //{
    //    public PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection)
    //    {
    //        managerLogger.AddLogMessage("Server", "Joining hub...");

    //        if(playerAndConnection != null && playerAndConnection.Player != null)
    //        {
    //            var character = JsonConvert.DeserializeObject<Character>(inc.ReadString());

    //            var outmsg = server.NetServer.CreateMessage();
    //            outmsg.Write((byte)PacketType.JoinHub);

    //            playerAndConnection.Player.CharacterActive = character;

    //            server.Hub.AddPlayer(playerAndConnection.Player);

    //            var str = JsonConvert.SerializeObject(server.Hub);
    //            outmsg.Write(str);

    //            managerLogger.AddLogMessage("Server", playerAndConnection.Player.Username + " joining hub !");

    //            playerAndConnection.Connection.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered, 0);

    //            //=======================
    //            outmsg = server.NetServer.CreateMessage();
    //            outmsg.Write((byte)PacketType.PlayerJoinHub);

    //            str = JsonConvert.SerializeObject(playerAndConnection.Player);
    //            outmsg.Write(str);

    //            server.NetServer.SendToAll(outmsg, playerAndConnection.Connection, NetDeliveryMethod.ReliableOrdered, 0);
    //        }

    //        return playerAndConnection;
    //    }

    //}
}
