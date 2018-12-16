using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.UI
{
    public class UIWindow : UIBaseElement
    {
        private Texture2D _lineTexture;
        private Texture2D _cornerTexture;
        private Texture2D _fillerTexture;
        private Color _color;

        public UIWindow(Point position, int width, int height, Color color)
        {
            Position = position;
            Height = height;
            Width = width;
            _color = color;
        }

        public override void LoadContent(ContentManager content)
        {
            ChangeColor(content, _color);

            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (Enable)
            {


                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Enable && Visible)
            {
                spriteBatch.Draw(_cornerTexture, new Rectangle((int)Position.X, (int)Position.Y, 4, 4), new Rectangle(0, 0, 4, 4), Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);

                spriteBatch.Draw(_cornerTexture, new Rectangle((int)Position.X, (int)Position.Y + Height - 4, 4, 4), new Rectangle(0, 0, 4, 4), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);

                spriteBatch.Draw(_cornerTexture, new Rectangle((int)Position.X + Width - 2, (int)Position.Y + 2, 4, 4), new Rectangle(0, 0, 4, 4), Color.White, 1.5708f, new Vector2(2, 2), SpriteEffects.None, 0);

                spriteBatch.Draw(_cornerTexture, new Rectangle((int)Position.X + Width - 2, (int)Position.Y + Height - 2, 4, 4), new Rectangle(0, 0, 4, 4), Color.White, -1.5708f, new Vector2(2, 2), SpriteEffects.FlipVertically, 0);

                //Top
                spriteBatch.Draw(_lineTexture, new Rectangle((int)Position.X + 4, (int)Position.Y, Width-8, 4), new Rectangle(0, 0, 4, 4), Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0);

                //Bottom
                spriteBatch.Draw(_lineTexture, new Rectangle((int)Position.X + 4, (int)Position.Y + Height - 4, Width - 8, 4), new Rectangle(0, 0, 4, 4), Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);

                //Left
                spriteBatch.Draw(_lineTexture, new Rectangle((int)Position.X + 2, (int)(Position.Y + Height * 0.5), Height - 8, 4), new Rectangle(0, 0, 4, 4), Color.White, 1.5708f, new Vector2(2, 2), SpriteEffects.FlipVertically, 0);

                //Right
                spriteBatch.Draw(_lineTexture, new Rectangle((int)Position.X + Width - 2, (int)(Position.Y + Height * 0.5), Height - 8, 4), new Rectangle(0, 0, 4, 4), Color.White, 1.5708f, new Vector2(2, 2), SpriteEffects.None, 0);

                spriteBatch.Draw(_fillerTexture, new Rectangle((int)Position.X + 4, (int)Position.Y + 4, Width - 8, Height - 8), Color.White);

                base.Draw(gameTime, spriteBatch);
            }
        }

        public void ChangeColor(ContentManager content, Color color)
        {
            var lineTexture = content.Load<Texture2D>("gui/window_line");
            var cornerTexture = content.Load<Texture2D>("gui/window_corner");
            var fillerTexture = content.Load<Texture2D>("blank");

            _lineTexture = new Texture2D(MyGame.Instance.GraphicsDevice, lineTexture.Width, lineTexture.Height);
            _cornerTexture = new Texture2D(MyGame.Instance.GraphicsDevice, cornerTexture.Width, cornerTexture.Height);
            _fillerTexture = new Texture2D(MyGame.Instance.GraphicsDevice, fillerTexture.Width, fillerTexture.Height);


            Color[] data = new Color[_fillerTexture.Width * _fillerTexture.Height];
            fillerTexture.GetData(data);

            for (int i = 0; i < data.Length; i++)
                if (data[i] == Color.White)
                    data[i] = color;

            _fillerTexture.SetData(data);

            data = new Color[_cornerTexture.Width * _cornerTexture.Height];
            cornerTexture.GetData(data);

            for (int i = 0; i < data.Length; i++)
                if (data[i] == Color.White)
                    data[i] = color;

            _cornerTexture.SetData(data);

            data = new Color[_lineTexture.Width * _lineTexture.Height];
            lineTexture.GetData(data);

            for (int i = 0; i < data.Length; i++)
                if (data[i] == Color.White)
                    data[i] = color;

            _lineTexture.SetData(data);
        }
    }
}
