using _2016_Project_2.Library.Enums;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class NetworkMessage
    {
        public PacketType Type { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }

        private NetConnection _source; 
        private List<NetConnection> _destinataires;

        public void SetSource(NetConnection source)
        {
            _source = source;
        }

        public void SetDestinataires(List<NetConnection> destinataires)
        {
            _destinataires = destinataires;
        }

        public NetConnection GetSource()
        {
            return _source;
        }

        public List<NetConnection> GetDestinataires()
        {
            return _destinataires;
        }
    }
}
