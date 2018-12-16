using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class LoginMessage : NetworkMessage
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid PlayerId { get; set; }

        public LoginMessage()
        {
            Type = Enums.PacketType.Login;
        }

        public static string Serialize(LoginMessage message)
        {
            return JsonConvert.SerializeObject(message);
        }

        public static LoginMessage Deserialize(string message)
        {
            return JsonConvert.DeserializeObject<LoginMessage>(message);
        }
    }
}
