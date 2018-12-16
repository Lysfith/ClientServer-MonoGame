using _2016_Project_2.Library.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class GetCharacterMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }

        public GetCharacterMessage()
        {
            Type = Enums.PacketType.Logout;
        }

        public static string Serialize(GetCharacterMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static GetCharacterMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<GetCharacterMessage>(message);
        }
    }
}
