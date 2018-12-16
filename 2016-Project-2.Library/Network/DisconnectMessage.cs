using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class DisconnectMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }

        public DisconnectMessage()
        {
            Type = Enums.PacketType.Disconnect;
        }

        public static string Serialize(DisconnectMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static DisconnectMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<DisconnectMessage>(message);
        }
    }
}
