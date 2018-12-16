using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class LogoutMessage : NetworkMessage
    {
        public Guid PlayerId { get; set; }

        public LogoutMessage()
        {
            Type = Enums.PacketType.Logout;
        }

        public static string Serialize(LogoutMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static LogoutMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<LogoutMessage>(message);
        }
    }
}
