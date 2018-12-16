using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Enums
{
    public enum PacketType
    {
        Login,
        Logout,
        Disconnect,
        GetCharacters,
        GetCharacter,
        CharacterCreation,
        CharacterDelete,
        JoinHub,
        PlayerJoinHub,
        PlayerQuitHub
    }
}
