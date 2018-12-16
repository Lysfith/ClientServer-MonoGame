using _2016_Project_2.Library.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class GetCharactersMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }
        public List<Character> Characters { get; set; }

        public GetCharactersMessage()
        {
            Type = Enums.PacketType.Login;
        }

        public static string Serialize(GetCharactersMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static GetCharactersMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<GetCharactersMessage>(message);
        }
    }
}
