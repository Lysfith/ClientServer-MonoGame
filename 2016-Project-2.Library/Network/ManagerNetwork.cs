using _2016_Project_2.Library.Enums;
using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2016_Project_2.Library.Network
{
    public class ManagerNetwork
    {
        private static ManagerNetwork _instance;

        public static ManagerNetwork Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerNetwork();
                }
                return _instance;
            }
        }

        private string _url;
        private int _port;

        private NetClient _client;
        private NetServer _server;
        private bool _isServer;

        private CancellationTokenSource _cancellationTokenSource;
        private Task _task;

        public event EventHandler<NetIncomingMessage> OnConnectionConnect;
        public event EventHandler<NetIncomingMessage> OnConnectionDisconnect;
        public event EventHandler<NetIncomingMessage> OnConnectionApproval;
        public event EventHandler<NetIncomingMessage> OnConnectionLatencyUpdated;
        public event EventHandler<LoginMessage> OnLogin;
        public event EventHandler<LogoutMessage> OnLogout;
        public event EventHandler<DisconnectMessage> OnDisconnect;
        public event EventHandler<GetCharactersMessage> OnGetCharacters;
        public event EventHandler<GetCharacterMessage> OnGetCharacter;
        public event EventHandler<CreateCharacterMessage> OnCreateCharacter;
        public event EventHandler<DeleteCharacterMessage> OnDeleteCharacter;

        public event EventHandler<LogMessage> OnNewLogMessage;

        public event EventHandler<EventArgs> OnClose;
        public event EventHandler<EventArgs> OnStop;

        public ManagerNetwork()
        {
            
        }

        public void Start(bool isServer, int port, string url = null)
        {
            _isServer = isServer;
            _url = url;
            _port = port;
            _cancellationTokenSource = new CancellationTokenSource();

            OnClose += Close;

            if (_isServer)
            {
                var config = new NetPeerConfiguration("networkGame")
                {
                    Port = _port,
                    PingInterval = 1f,
                    ConnectionTimeout = 5f
                };
                config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
                config.EnableMessageType(NetIncomingMessageType.ConnectionLatencyUpdated);
                config.EnableMessageType(NetIncomingMessageType.WarningMessage);
                config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
                config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
                config.EnableMessageType(NetIncomingMessageType.Error);
                config.EnableMessageType(NetIncomingMessageType.DebugMessage);
                _server = new NetServer(config);
                _server.Start();
            }
            else
            {
                var config = new NetPeerConfiguration("networkGame")
                {
                    PingInterval = 1f,
                    ConnectionTimeout = 5f
                };
                config.EnableMessageType(NetIncomingMessageType.WarningMessage);
                config.EnableMessageType(NetIncomingMessageType.VerboseDebugMessage);
                config.EnableMessageType(NetIncomingMessageType.ErrorMessage);
                config.EnableMessageType(NetIncomingMessageType.Error);
                config.EnableMessageType(NetIncomingMessageType.DebugMessage);
                _client = new NetClient(config);
                _client.Start();
                _client.Connect(_url, _port);
            }

            _task = new Task(() =>
            {
                Run(_cancellationTokenSource.Token);
            });
            _task.Start();
        }

        public void Stop()
        {
            if (_isServer)
            {
                _server.Shutdown("Server shutdown");
            }
            else
            {
                _client.Shutdown("Client shutdown");
            }
            
        }

        public void Close(object sender, EventArgs e)
        {
            
        }

        public void OnStopEvent(object sender, EventArgs e)
        {

        }

        public void Run(CancellationToken cancelToken)
        {
            while (true)
            {
                if ((_isServer && _server.Status == NetPeerStatus.NotRunning)
                    || (!_isServer && _client.Status == NetPeerStatus.NotRunning))
                {
                    if (OnStop != null)
                    {
                        OnStop(this, null);
                    }
                    return;
                }

                //if (cancelToken.IsCancellationRequested)
                //{
                //    if(OnClose != null)
                //    {
                //        OnClose(this, null);
                //    }
                //    return;
                //}

                if ((_isServer && _server.Status == NetPeerStatus.Running)
                    || (!_isServer && _client.Status == NetPeerStatus.Running))
                {
                    NetIncomingMessage inc;

                    if (_isServer)
                    {
                        inc = _server.ReadMessage();
                    }
                    else
                    {
                        inc = _client.ReadMessage();
                    }

                    if (inc == null)
                    {
                        Thread.Sleep(1);
                        continue;
                    }

                    switch (inc.MessageType)
                    {
                        case NetIncomingMessageType.ConnectionApproval:
                            //if (OnConnectionApproval != null)
                            //{
                            //    OnConnectionApproval(this, inc);
                            //}
                            break;
                        case NetIncomingMessageType.ConnectionLatencyUpdated:
                            if (OnConnectionLatencyUpdated != null)
                            {
                                OnConnectionLatencyUpdated(this, inc);
                            }
                            break;
                        case NetIncomingMessageType.Data:
                            Data(inc);
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            StatusChanged(inc);
                            break;
                        case NetIncomingMessageType.ErrorMessage:
                            if (OnNewLogMessage != null)
                            {
                                OnNewLogMessage(this,
                                    new LogMessage
                                    {
                                        Id = "",
                                        Message = inc.ReadString(),
                                        Date = DateTime.Now,
                                        Type = TypeLog.ERROR
                                    });
                            }
                            break;
                        case NetIncomingMessageType.WarningMessage:
                            if (OnNewLogMessage != null)
                            {
                                OnNewLogMessage(this,
                                    new LogMessage
                                    {
                                        Id = "",
                                        Message = inc.ReadString(),
                                        Date = DateTime.Now,
                                        Type = TypeLog.WARNING
                                    });
                            }
                            break;
                        case NetIncomingMessageType.VerboseDebugMessage:
                        case NetIncomingMessageType.DebugMessage:
                            if (OnNewLogMessage != null)
                            {
                                OnNewLogMessage(this,
                                    new LogMessage
                                    {
                                        Id = "",
                                        Message = inc.ReadString(),
                                        Date = DateTime.Now,
                                        Type = TypeLog.DEBUG
                                    });
                            }
                            break;
                    }
                }
            }
        }

        private void Data(NetIncomingMessage inc)
        {
            var packageType = (PacketType)inc.ReadByte();
            switch (packageType)
            {
                case PacketType.Login:
                    var messageLogin = LoginMessage.Deserialize(inc.ReadString());
                    messageLogin.SetSource(inc.SenderConnection);

                    if(OnLogin != null)
                    {
                        OnLogin(this, messageLogin);
                    }
                    break;
                case PacketType.Logout:
                    var messageLogout = LogoutMessage.Deserialize(inc.ReadString());
                    messageLogout.SetSource(inc.SenderConnection);

                    if (OnLogout != null)
                    {
                        OnLogout(this, messageLogout);
                    }
                    break;
                case PacketType.Disconnect:
                    var messageDisconnect = DisconnectMessage.Deserialize(inc.ReadString());
                    messageDisconnect.SetSource(inc.SenderConnection);

                    if (OnDisconnect != null)
                    {
                        OnDisconnect(this, messageDisconnect);
                    }
                    break;
                case PacketType.GetCharacters:
                    var messageGetCharacters = GetCharactersMessage.Deserialize(inc.ReadString());
                    messageGetCharacters.SetSource(inc.SenderConnection);

                    if (OnGetCharacters != null)
                    {
                        OnGetCharacters(this, messageGetCharacters);
                    }
                    break;
                case PacketType.GetCharacter:
                    var messageGetCharacter = GetCharacterMessage.Deserialize(inc.ReadString());
                    messageGetCharacter.SetSource(inc.SenderConnection);

                    if (OnGetCharacter != null)
                    {
                        OnGetCharacter(this, messageGetCharacter);
                    }
                    break;
                case PacketType.CharacterCreation:
                    var messageCharacterCreation = CreateCharacterMessage.Deserialize(inc.ReadString());
                    messageCharacterCreation.SetSource(inc.SenderConnection);

                    if (OnCreateCharacter != null)
                    {
                        OnCreateCharacter(this, messageCharacterCreation);
                    }
                    break;

                case PacketType.CharacterDelete:
                    var messageCharacterDelete = DeleteCharacterMessage.Deserialize(inc.ReadString());
                    messageCharacterDelete.SetSource(inc.SenderConnection);

                    if (OnDeleteCharacter != null)
                    {
                        OnDeleteCharacter(this, messageCharacterDelete);
                    }
                    break;
                case PacketType.JoinHub:
                    
                    break;
                case PacketType.PlayerJoinHub:
                    
                    break;
                case PacketType.PlayerQuitHub:
                    
                    break;
            }
        }

        private void StatusChanged(NetIncomingMessage inc)
        {
            var status = (NetConnectionStatus)inc.ReadByte();
            switch (status)
            {
                case NetConnectionStatus.Connected:
                    if (OnNewLogMessage != null)
                    {
                        OnNewLogMessage(this,
                            new LogMessage
                            {
                                Id = "",
                                Message = inc.ReadString(),
                                Date = DateTime.Now,
                                Type = TypeLog.INFO
                            });
                    }

                    if (OnConnectionConnect != null)
                    {
                        OnConnectionConnect(this, inc);
                    }
                    break;
                case NetConnectionStatus.Disconnected:
                    if (!_isServer)
                    {
                        _client.Connect(_url, _port);
                    }

                    if (OnNewLogMessage != null)
                    {
                        OnNewLogMessage(this,
                            new LogMessage
                            {
                                Id = "",
                                Message = inc.ReadString(),
                                Date = DateTime.Now,
                                Type = TypeLog.INFO
                            });
                    }

                    if (OnConnectionDisconnect != null)
                    {
                        OnConnectionDisconnect(this, inc);
                    }
                    break;
                case NetConnectionStatus.RespondedAwaitingApproval:
                    if (OnConnectionApproval != null)
                    {
                        OnConnectionApproval(this, inc);
                    }
                    break;
            }
        }

        #region Send methods
        public void Login(LoginMessage message)
        {
            SendMessage(PacketType.Login, LoginMessage.Serialize(message), message.GetDestinataires());
        }

        public void Logout(LogoutMessage message)
        {
            SendMessage(PacketType.Logout, LogoutMessage.Serialize(message), message.GetDestinataires());
        }

        public void Disconnect(DisconnectMessage message)
        {
            SendMessage(PacketType.Disconnect, DisconnectMessage.Serialize(message), message.GetDestinataires());
        }

        public void GetCharacters(GetCharactersMessage message)
        {
            SendMessage(PacketType.GetCharacters, GetCharactersMessage.Serialize(message), message.GetDestinataires());
        }

        private void SendMessage(PacketType type, string message, List<NetConnection> destinataires = null)
        {
            if(_isServer)
            {
                var outmessage = _server.CreateMessage();

                outmessage.Write((byte)type);
                outmessage.Write(message);

                _server.SendMessage(outmessage, destinataires, NetDeliveryMethod.ReliableOrdered, 0);
            }
            else
            {
                var outmessage = _client.CreateMessage();

                outmessage.Write((byte)type);
                outmessage.Write(message);

                _client.SendMessage(outmessage, NetDeliveryMethod.ReliableOrdered);
            }
            
        }
        #endregion
    }
}
