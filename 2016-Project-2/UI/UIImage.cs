using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.UI
{
    public class UIImage : UIBaseElement
    {
        public string Path { get; set; }

        private Texture2D _texture;


        public UIImage(Point position, int width, int height, string path)
        {
            Position = position;
            Width = width;
            Height = height;
            Path = path;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            _texture = content.Load<Texture2D>(Path);
        }

        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Enable && Visible)
            {
                spriteBatch.Draw(_texture, new Rectangle(Position.X, Position.Y, Width, Height), Color.White);
            }

            base.Draw(gameTime, spriteBatch);
        }
    }
}
