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
    //class DisconnectCommand : ICommand
    //{
    //    public PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection)
    //    {
    //        managerLogger.AddLogMessage("Server", string.Format("Disconnect {0}", playerAndConnection.Player.Username));
    //        var outmessage = server.NetServer.CreateMessage();
    //        outmessage.Write((byte)PacketType.Disconnect);
    //        outmessage.Write(playerAndConnection.Player.Username);
    //        server.NetServer.SendToAll(outmessage, NetDeliveryMethod.ReliableOrdered);
    //        //Kick player
    //        //playerAndConnection.Connection.Disconnect("Server is out");
    //        playerAndConnection.Connection.Deny("Server is out");

    //        //=======================

    //        server.Hub.RemovePlayer(playerAndConnection.Player);

    //        var outmsg = server.NetServer.CreateMessage();
    //        outmsg.Write((byte)PacketType.PlayerQuitHub);

    //        var str = JsonConvert.SerializeObject(playerAndConnection.Player);
    //        outmsg.Write(str);

    //        server.NetServer.SendToAll(outmsg, playerAndConnection.Connection, NetDeliveryMethod.ReliableOrdered, 0);

    //        return playerAndConnection;
    //    }
    //}
}
