using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class CreateCharacterMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }
        public string CharacterName { get; set; }
        public EnumCharacterModel CharacterModel { get; set; }
        public Character Character { get; set; }

        public CreateCharacterMessage()
        {
            Type = Enums.PacketType.CharacterCreation;
        }
        
        public static string Serialize(CreateCharacterMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static CreateCharacterMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<CreateCharacterMessage>(message);
        }
    }
}
