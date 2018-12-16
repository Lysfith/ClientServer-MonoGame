namespace _2016_Project_2.Server.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_stopServer = new System.Windows.Forms.Button();
            this.btn_startServer = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.list_players = new System.Windows.Forms.ListBox();
            this.contextMenuPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.playerMenu_disconnectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hub_group = new System.Windows.Forms.GroupBox();
            this.hub = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuPlayer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.hub_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_stopServer);
            this.groupBox1.Controls.Add(this.btn_startServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commands";
            // 
            // btn_stopServer
            // 
            this.btn_stopServer.Enabled = false;
            this.btn_stopServer.Location = new System.Drawing.Point(92, 20);
            this.btn_stopServer.Name = "btn_stopServer";
            this.btn_stopServer.Size = new System.Drawing.Size(75, 23);
            this.btn_stopServer.TabIndex = 1;
            this.btn_stopServer.Text = "Stop server";
            this.btn_stopServer.UseVisualStyleBackColor = true;
            this.btn_stopServer.Click += new System.EventHandler(this.btn_stopServer_Click);
            // 
            // btn_startServer
            // 
            this.btn_startServer.Location = new System.Drawing.Point(7, 20);
            this.btn_startServer.Name = "btn_startServer";
            this.btn_startServer.Size = new System.Drawing.Size(78, 23);
            this.btn_startServer.TabIndex = 0;
            this.btn_startServer.Text = "Start server";
            this.btn_startServer.UseVisualStyleBackColor = true;
            this.btn_startServer.Click += new System.EventHandler(this.btn_startServer_Click);
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.MenuText;
            this.console.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.console.Location = new System.Drawing.Point(7, 19);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(747, 577);
            this.console.TabIndex = 1;
            this.console.UseCompatibleStateImageBehavior = false;
            this.console.View = System.Windows.Forms.View.List;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.list_players);
            this.groupBox2.Location = new System.Drawing.Point(779, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 606);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Players";
            // 
            // list_players
            // 
            this.list_players.ContextMenuStrip = this.contextMenuPlayer;
            this.list_players.FormattingEnabled = true;
            this.list_players.Location = new System.Drawing.Point(7, 20);
            this.list_players.Name = "list_players";
            this.list_players.Size = new System.Drawing.Size(178, 576);
            this.list_players.TabIndex = 0;
            // 
            // contextMenuPlayer
            // 
            this.contextMenuPlayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kickToolStripMenuItem});
            this.contextMenuPlayer.Name = "contextMenuPlayer";
            this.contextMenuPlayer.Size = new System.Drawing.Size(97, 26);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1265, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playersMenu
            // 
            this.playersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerMenu_disconnectAll});
            this.playersMenu.Name = "playersMenu";
            this.playersMenu.Size = new System.Drawing.Size(56, 20);
            this.playersMenu.Text = "Players";
            // 
            // playerMenu_disconnectAll
            // 
            this.playerMenu_disconnectAll.Name = "playerMenu_disconnectAll";
            this.playerMenu_disconnectAll.Size = new System.Drawing.Size(148, 22);
            this.playerMenu_disconnectAll.Text = "Disconnect all";
            this.playerMenu_disconnectAll.Click += new System.EventHandler(this.playerMenu_disconnectAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.console);
            this.groupBox3.Location = new System.Drawing.Point(13, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 606);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // hub_group
            // 
            this.hub_group.Controls.Add(this.hub);
            this.hub_group.Location = new System.Drawing.Point(976, 84);
            this.hub_group.Name = "hub_group";
            this.hub_group.Size = new System.Drawing.Size(191, 606);
            this.hub_group.TabIndex = 6;
            this.hub_group.TabStop = false;
            this.hub_group.Text = "Hub";
            // 
            // hub
            // 
            this.hub.ContextMenuStrip = this.contextMenuPlayer;
            this.hub.FormattingEnabled = true;
            this.hub.Location = new System.Drawing.Point(7, 20);
            this.hub.Name = "hub";
            this.hub.Size = new System.Drawing.Size(178, 576);
            this.hub.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 702);
            this.Controls.Add(this.hub_group);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuPlayer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.hub_group.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_startServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_stopServer;
        private System.Windows.Forms.ListView console;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox list_players;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayer;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playersMenu;
        private System.Windows.Forms.ToolStripMenuItem playerMenu_disconnectAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox hub_group;
        private System.Windows.Forms.ListBox hub;
    }
}