using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.States
{
    public enum EnumState
    {
        LOGIN,
        CHARACTER_SELECT,
        CHARACTER_CREATION,
        HUB,
        GAME,
        TEST
    }

    public interface IState
    {
        void Start();
        void End();
        void Initialize(GraphicsDeviceManager graphics);
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
