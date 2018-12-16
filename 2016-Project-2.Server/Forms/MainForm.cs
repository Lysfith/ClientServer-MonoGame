using _2016_Project_2.Server.Util;
using _2016_Project_2.Server.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Network;

namespace _2016_Project_2.Server.Forms
{
    public partial class MainForm : Form
    {
        private Server _server;

        public MainForm()
        {
            ManagerLogger.Instance.OnNewLogMessage += NewLogMessageEvent;
            ManagerNetwork.Instance.OnStop += OnStop;
            _server = new Server();
            //_server.PlayersListChangeEvent += PlayersListChangeEvent;
            //_server.HubChangeEvent += HubChangeEvent;

            InitializeComponent();
        }

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            btn_startServer.Enabled = false;
            btn_stopServer.Enabled = true;
            
            _server.Start();
        }

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            btn_stopServer.Enabled = false;
            _server.Stop();
        }

        void OnStop(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<EventArgs>(OnStop), sender, e);
                return;
            }

            ManagerLogger.Instance.AddLogMessage("Server", "Server stopped !");

            btn_startServer.Enabled = true;
            btn_stopServer.Enabled = false;
        }

        void NewLogMessageEvent(object sender, LogMessage e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<LogMessage>(NewLogMessageEvent), sender, e);
                return;
            }

            Color fontColor = Color.White;

            switch(e.Type)
            {
                case TypeLog.DEBUG:
                    fontColor = Color.Green;
                    break;
                case TypeLog.WARNING:
                    fontColor = Color.Yellow;
                    break;
                case TypeLog.ERROR:
                    fontColor = Color.Red;
                    break;
            }


            var t = new ListViewItem()
            {
                ForeColor = fontColor,
                Text = e.ToStringLine()
            };
            console.Items.Add(t);
        }

        void PlayersListChangeEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<EventArgs>(PlayersListChangeEvent), sender, e);
                return;
            }

            var indexSelected = list_players.SelectedIndex;
            list_players.Items.Clear();

            //var players = _server.GetPlayers().Select(x => GetPlayerName(x));

            //foreach(var player in players)
            //{

            //    list_players.Items.Add(player);
            //}

            //if(list_players.Items.Count > 0)
            //{
            //    list_players.SelectedIndex = indexSelected;
            //}
            
        }

        void HubChangeEvent(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<EventArgs>(HubChangeEvent), sender, e);
                return;
            }

            var indexSelected = hub.SelectedIndex;
            hub.Items.Clear();

            var players = _server.Hub.GetPlayers().Select(x => GetPlayerName(x));

            foreach (var player in players)
            {

                hub.Items.Add(player);
            }

            if (hub.Items.Count > 0)
            {
                hub.SelectedIndex = indexSelected;
            }

        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list_players.SelectedIndex == -1)
            {
                MessageBox.Show("Select a player first");
                return;
            }

            var username = list_players.Items[list_players.SelectedIndex].ToString();

            var str = username.Split('[', ']');

            _server.KickPlayer(Int32.Parse(str[1]));
            list_players.Items.RemoveAt(list_players.SelectedIndex);
        }

        private void playerMenu_disconnectAll_Click(object sender, EventArgs e)
        {
            _server.DisconnectAllPlayers();
        }

        private string GetPlayerName(PlayerAndConnection conn)
        {
            return "[" + conn.Id + "] " + conn.Player.Username + " ("
                + (conn.Latency < 1.0 ? (conn.Latency * 1000).ToString("0.0000") + " ms" : conn.Latency.ToString("0.0000") + " s") + ")";
        }

        private string GetPlayerName(Player player)
        {
            return player.Username;
        }
    }
}
