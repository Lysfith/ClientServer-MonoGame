using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _2016_Project_2.UI;
using _2016_Project_2.Managers;
using _2016_Project_2.Library.Entities;
using _2016_Project_2.UI.Advanced;
using _2016_Project_2.Library.Network;

namespace _2016_Project_2.States
{
    public class HubState : State
    {

        private Player _player;

        private Library.Entities.Hub _hub;

        private UILabel _lbl_listPlayers;

        private Dictionary<Player, CharacterAnimation> _sprites;
        private Dictionary<Player, CharacterAnimation> _spritesToAdd;

        public override void Start()
        {
            base.Start();
            
            //ManagerNetwork.Instance.OnPlayerJoinHub += CharacterCreation_OnPlayerJoinHub;
            //ManagerNetwork.Instance.OnPlayerQuitHub += CharacterCreation_OnPlayerQuitHub;

            _player = ManagerPlayer.Instance.Player;

            _hub = ManagerPlayer.Instance.Hub;

            _sprites = new Dictionary<Player, CharacterAnimation>();
            _spritesToAdd = new Dictionary<Player, CharacterAnimation>();


        }

        public override void End()
        {
            base.End();
            
            //ManagerNetwork.Instance.OnPlayerJoinHub -= CharacterCreation_OnPlayerJoinHub;
            //ManagerNetwork.Instance.OnPlayerQuitHub -= CharacterCreation_OnPlayerQuitHub;


        }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            //UI
            _lbl_listPlayers = new UILabel(new Point(10, 10), 200, 40, "");

            ManagerUI.Instance.AddItem(_lbl_listPlayers);

            foreach (var player in ManagerPlayer.Instance.Hub.GetPlayers())
            {
                CreateCharacterAnimation(player,
                    new Point((int)(graphics.PreferredBackBufferWidth * 0.5), (int)(graphics.PreferredBackBufferHeight * 0.5)));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(_spritesToAdd.Any())
            {
                foreach (var item in _spritesToAdd)
                {
                    _sprites.Add(item.Key, item.Value);
                }
                _spritesToAdd.Clear();
            }

            _lbl_listPlayers.Text = "";

            var players = _hub.GetPlayers();
            foreach (var player in players)
            {
                _lbl_listPlayers.Text += player.Username + "\n";
            }

            foreach (var sprite in _sprites)
            {
                sprite.Value.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            foreach (var sprite in _sprites)
            {
                sprite.Value.Draw(gameTime, spriteBatch);
            }

        }

        private void CreateCharacterAnimation(Player player, Point position)
        {
            var definition = new CharacterAnimationDefinition()
            {
                Character = player.CharacterActive,
                FrameRate = 10,
                FrameSize = new Point(24, 32),
                Scale = new Point(2, 2),
                Loop = true,
                NbFrames = new Point(3, 1)
            };

            var animation = new CharacterAnimation(definition, position);

            _spritesToAdd.Add(player, animation);
        }

        #region Events
        public void CharacterCreation_OnLogout(object sender, EventArgs e)
        {
            ManagerState.Instance.ChangeState(EnumState.LOGIN);
        }

        public void CharacterCreation_OnDisconnect(object sender, EventArgs e)
        {
            ManagerState.Instance.ChangeState(EnumState.LOGIN);
        }

        public void CharacterCreation_OnPlayerJoinHub(object sender, Player player)
        {
            _hub.AddPlayer(player);

            CreateCharacterAnimation(player,
                new Point((int)(MyGame.Instance.Graphics.PreferredBackBufferWidth * 0.5), (int)(MyGame.Instance.Graphics.PreferredBackBufferHeight * 0.5)));
        }

        public void CharacterCreation_OnPlayerQuitHub(object sender, Player player)
        {
            _hub.RemovePlayer(player);
        }
        #endregion

    }
}
