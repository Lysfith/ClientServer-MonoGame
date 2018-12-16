using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using _2016_Project_2.Managers;
using _2016_Project_2.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.UI.Advanced
{
    public class CharacterSelect : UIBaseElement
    {
        public EnumCharacterModel Model { get; private set; }

        private Dictionary<EnumCharacterModel, UIImage> _modelTextures;

        private UIButton _btn_left;
        private UIButton _btn_right;

        private DateTime _lastInput;

        public CharacterSelect(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;

        }

        public void Initialize(GraphicsDeviceManager graphics)
        {
            _modelTextures = new Dictionary<EnumCharacterModel, UIImage>();

            _btn_left = new UIButton(new Point(Position.X, Position.Y + (int)(Height * 0.5)), 50, 40, "<");
            _btn_left.OnGainFocus += (sender, e) =>
            {
                if ((DateTime.Now - _lastInput).TotalMilliseconds > 500)
                {
                    foreach (var item in _modelTextures)
                    {
                        item.Value.Visible = false;
                    }

                    var values = ((EnumCharacterModel[])Enum.GetValues(typeof(EnumCharacterModel))).ToList();
                    var index = values.IndexOf(Model);

                    index--;

                    if (index < 0)
                    {
                        index = values.Count - 1;
                    }

                    Model = values.ElementAt(index);
                    _modelTextures[Model].Visible = true;

                    _lastInput = DateTime.Now;
                }
            };

            _btn_right = new UIButton(new Point(Position.X + Width - 50, Position.Y + (int)(Height * 0.5)), 50, 40, ">");
            _btn_right.OnGainFocus += (sender, e) =>
            {
                if ((DateTime.Now - _lastInput).TotalMilliseconds > 500)
                {
                    foreach (var item in _modelTextures)
                    {
                        item.Value.Visible = false;
                    }

                    var values = ((EnumCharacterModel[])Enum.GetValues(typeof(EnumCharacterModel))).ToList();
                    var index = values.IndexOf(Model);

                    index++;

                    if (index >= values.Count)
                    {
                        index = 0;
                    }

                    Model = values.ElementAt(index);
                    _modelTextures[Model].Visible = true;

                    _lastInput = DateTime.Now;
                }
            };

            _lastInput = DateTime.Now;

            AddChild(_btn_left);
            AddChild(_btn_right);

            _modelTextures.Add(EnumCharacterModel.MODEL_1, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/AerisA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_2, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/BarretA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_3, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CaitSithA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_4, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CidA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_5, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CloudA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_6, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/NanakiA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_7, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/TifaA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_8, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/VincentA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_9, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/YoufieA"));

            foreach (var item in _modelTextures)
            {
                item.Value.Visible = false;
                AddChild(item.Value);
            }

            _modelTextures[0].Visible = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (Enable && Visible)
            {
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(Enable && Visible)
            {
                base.Draw(gameTime, spriteBatch);
            }
        }

    }
}
