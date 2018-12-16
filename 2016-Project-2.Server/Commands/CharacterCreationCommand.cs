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
    //class CharacterCreationCommand : ICommand
    //{
    //    public PlayerAndConnection Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playerAndConnection)
    //    {
    //        managerLogger.AddLogMessage("Server", "Character Creation...");

    //        if(playerAndConnection != null && playerAndConnection.Player != null)
    //        {
    //            var character = JsonConvert.DeserializeObject<Character>(inc.ReadString());

    //            playerAndConnection = CreateCharacter(playerAndConnection, character);

    //            var outmsg = server.NetServer.CreateMessage();
    //            outmsg.Write((byte)PacketType.CharacterCreation);
    //            var str = JsonConvert.SerializeObject(playerAndConnection.Player);
    //            outmsg.Write(str);

    //            managerLogger.AddLogMessage("Server", "Character " + character.Name + " created for " + playerAndConnection.Player.Username + "");

    //            playerAndConnection.Connection.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered, 0);
    //        }

    //        return playerAndConnection;
    //    }

    //    private PlayerAndConnection CreateCharacter(PlayerAndConnection playerAndConnection, Character characterModel)
    //    {
    //        var random = new Random();
    //        var character = new Character(characterModel.Name, characterModel.Model);

    //        playerAndConnection.Player.Characters.Add(character);

    //        return playerAndConnection;
    //    }

    //}
}
