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
    //class CharacterDeleteCommand : ICommand
    //{
    //    public PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection)
    //    {
    //        managerLogger.AddLogMessage("Server", "Character Delete...");

    //        if(playerAndConnection != null && playerAndConnection.Player != null)
    //        {
    //            var character = JsonConvert.DeserializeObject<Character>(inc.ReadString());

    //            playerAndConnection = DeleteCharacter(playerAndConnection, character);

    //            var outmsg = server.NetServer.CreateMessage();
    //            outmsg.Write((byte)PacketType.CharacterDelete);
    //            var str = JsonConvert.SerializeObject(playerAndConnection.Player);
    //            outmsg.Write(str);

    //            managerLogger.AddLogMessage("Server", "Character " + character.Name + " deleted for " + playerAndConnection.Player.Username + "");

    //            playerAndConnection.Connection.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered, 0);
    //        }

    //        return playerAndConnection;
    //    }

    //    private PlayerAndConnection DeleteCharacter(PlayerAndConnection playerAndConnection, Character character)
    //    {
    //        playerAndConnection.Player.Characters.RemoveAll(x => x.Name == character.Name);

    //        return playerAndConnection;
    //    }

    //}
}
