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
    public class DeleteCharacterMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }
        public Guid CharacterId { get; set; }

        public DeleteCharacterMessage()
        {
            Type = Enums.PacketType.CharacterDelete;
        }

        public static string Serialize(DeleteCharacterMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static DeleteCharacterMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<DeleteCharacterMessage>(message);
        }
    }
}
