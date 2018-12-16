using _2016_Project_2.Library;
using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using _2016_Project_2.Library.Network;
using _2016_Project_2.Server.Commands;
using _2016_Project_2.Server.Managers;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2016_Project_2.Server
{
    class Server
    {
        private Dictionary<long, NetConnection> _connections;

        //private DateTime _lastRefreshPlayersList;
        //public event EventHandler<EventArgs> PlayersListChangeEvent;
        //public event EventHandler<EventArgs> HubChangeEvent;

        public Hub Hub;

        public Server()
        {
            _connections = new Dictionary<long, NetConnection>();

            //_lastRefreshPlayersList = DateTime.Now;

            Hub = new Hub();
        }

        public void Start()
        {
            ManagerLogger.Instance.AddLogMessage("Server", "Server starting...");

            ManagerNetwork.Instance.OnConnectionApproval += OnConnectionApproval;
            ManagerNetwork.Instance.OnConnectionDisconnect += OnConnectionDisconnect;
            ManagerNetwork.Instance.OnLogin += OnLogin;
            ManagerNetwork.Instance.OnGetCharacters += OnGetCharacters;
            ManagerNetwork.Instance.OnNewLogMessage += OnNewLogMessage;

            ManagerNetwork.Instance.Start(true, 14241);

            ManagerLogger.Instance.AddLogMessage("Server", "Server started !");

            
        }

        public void Stop()
        {
            ManagerLogger.Instance.AddLogMessage("Server", "Server stopping...");

            DisconnectAllPlayers();

            ManagerNetwork.Instance.Stop();

           
        }

        #region Events
        public void OnNewLogMessage(object sender, LogMessage message)
        {
            ManagerLogger.Instance.AddLogMessage(message);
        }

        public void OnConnectionApproval(object sender, NetIncomingMessage message)
        {
            if (message.SenderConnection.Status == NetConnectionStatus.RespondedAwaitingApproval)
            {
                message.SenderConnection.Approve();

                if (!_connections.ContainsKey(message.SenderConnection.RemoteUniqueIdentifier))
                {
                    _connections.Add(message.SenderConnection.RemoteUniqueIdentifier, message.SenderConnection);
                }
            }
        }

        public void OnConnectionDisconnect(object sender, NetIncomingMessage message)
        {
            _connections.Remove(message.SenderConnection.RemoteUniqueIdentifier);
        }

        public void OnLogin(object sender, LoginMessage message)
        {
            if (_connections.ContainsKey(message.GetSource().RemoteUniqueIdentifier))
            {
                var connection = _connections[message.GetSource().RemoteUniqueIdentifier];

                Guid playerId;
                var player = ManagerPlayer.Instance.GetPlayerByConnectionId(message.GetSource().RemoteUniqueIdentifier);
                if (player == null)
                {
                    playerId = ManagerPlayer.Instance.AddPlayer(connection, message.UserName);
                }
                else
                {
                    playerId = player.Player.Id;

                    message.Message = "Player already logged";
                }

                message.Result = true;
                message.PlayerId = playerId;
                message.SetDestinataires(new List<NetConnection>() { connection });

                ManagerNetwork.Instance.Login(message);
            }
            else
            {
                throw new Exception("Connection not finded");
            }

            
        }

        public void OnGetCharacters(object sender, GetCharactersMessage message)
        {
            var player = ManagerPlayer.Instance.GetPlayerById(message.PlayerId);
            if (player != null)
            {
                message.Characters = player.Player.Characters;
                message.Result = true;
            }
            else
            {
                message.Result = false;
                message.Message = "Player unknown";
            }

            message.SetDestinataires(new List<NetConnection>() { message.GetSource() });

            ManagerNetwork.Instance.GetCharacters(message);

        }
        #endregion

        public void SendNewPlayerEvent(string username, string gameGroupId)
        {
            //if (NewPlayerEvent != null)
            //    NewPlayerEvent(this, new NewPlayerEventArgs(string.Format("{0}[{1}]", username, gameGroupId)));
        }

        public void KickPlayer(int id)
        {
            //var command = PacketFactory.GetCommand(PacketType.Disconnect);
            //var player = _players.FirstOrDefault(p => p.Id == id);

            //if (player != null)
            //{
            //    command.Run(_managerLogger, this, null, player);

            //    _players.RemoveAll(x => x.Id == id);
            //}
        }

        public void DisconnectAllPlayers()
        {
            foreach (var connection in ManagerPlayer.Instance.GetPlayers())
            {
                var message = new DisconnectMessage()
                {
                    Message = "Server stopping",
                    PlayerId = connection.Value.Player.Id
                };
                message.SetDestinataires(new List<NetConnection>() { connection.Value.Connection });
                ManagerNetwork.Instance.Disconnect(message);
                //connection.Value.Connection.Deny("Server stopped !");
            }
            _connections.Clear();
            ManagerPlayer.Instance.Clear();
        }
    }
}
