using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
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
    public class CharacterAnimationDefinition
    {
        public Character Character { get; set; }
        public Point FrameSize { get; set; }
        public Point Scale { get; set; }
        public Point NbFrames { get; set; }
        public Point Origin { get; set; }
        public int FrameRate { get; set; }
        public bool Loop { get; set; }
    }

    public class CharacterAnimation
    {
        public Point Position { get; set; }

        protected CharacterAnimationDefinition Definition;
        protected Point CurrentFrame;
        protected bool FinishedAnimation = false;
        protected double TimeBetweenFrame = 16; // 60 fps 
        protected double lastFrameUpdatedTime = 0;

        private int _Framerate = 60;
        public int Framerate
        {
            get { return this._Framerate; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Framerate can't be less or equal to 0");
                if (this._Framerate != value)
                {
                    this._Framerate = value;
                    this.TimeBetweenFrame = 1000.0d / (double)this._Framerate;
                }
            }
        }

        private Texture2D _spriteSheet;

        public CharacterAnimation(CharacterAnimationDefinition definition, Point position)
        {
            Position = position;
            Definition = definition;

            Framerate = definition.FrameRate;

            switch (Definition.Character.Model)
            {
                case EnumCharacterModel.MODEL_1:
                    Definition.Origin = new Point(9, 0);
                    break;
                case EnumCharacterModel.MODEL_2:
                    Definition.Origin = new Point(12, 0);
                    break;
                case EnumCharacterModel.MODEL_3:
                    Definition.Origin = Point.Zero;
                    break;
                case EnumCharacterModel.MODEL_4:
                    Definition.Origin = new Point(6, 4);
                    break;
                case EnumCharacterModel.MODEL_5:
                    Definition.Origin = Point.Zero;
                    break;
                case EnumCharacterModel.MODEL_6:
                    Definition.Origin = Point.Zero;
                    break;
                case EnumCharacterModel.MODEL_7:
                    Definition.Origin = new Point(6, 0);
                    break;
                case EnumCharacterModel.MODEL_8:
                    Definition.Origin = new Point(3, 4);
                    break;
                case EnumCharacterModel.MODEL_9:
                    Definition.Origin = new Point(0, 4);
                    break;
            }

            CurrentFrame = Definition.Origin;
            CurrentFrame.Y += (int)Definition.Character.Direction;

            _spriteSheet = MyGame.Instance.Content.Load<Texture2D>("Characters/FF7chars");
        }

        public void Reset()
        {
            this.CurrentFrame = Point.Zero;
            this.FinishedAnimation = false;
            this.lastFrameUpdatedTime = 0;
        }

        public void Initialize(GraphicsDeviceManager graphics)
        {

        }

        public void LoadContent(ContentManager content)
        {
           
        }

        public void Update(GameTime gameTime)
        {
            if (FinishedAnimation) return;
            
            var origin = Definition.Origin;

            origin.Y += (int)Definition.Character.Direction;

            this.lastFrameUpdatedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (this.lastFrameUpdatedTime > this.TimeBetweenFrame)
            {
                this.lastFrameUpdatedTime = 0;
                if (this.Definition.Loop)
                {
                    this.CurrentFrame.X++;
                    if (this.CurrentFrame.X >= this.Definition.NbFrames.X + origin.X)
                    {
                        this.CurrentFrame.X = origin.X;
                        this.CurrentFrame.Y++;
                        if (this.CurrentFrame.Y >= this.Definition.NbFrames.Y + origin.Y)
                            this.CurrentFrame.Y = origin.Y;
                    }
                }
                else
                {
                    this.CurrentFrame.X++;
                    if (this.CurrentFrame.X >= this.Definition.NbFrames.X + origin.X)
                    {
                        this.CurrentFrame.X = origin.X;
                        this.CurrentFrame.Y++;
                        if (this.CurrentFrame.Y >= this.Definition.NbFrames.Y + origin.Y)
                        {
                            this.CurrentFrame.X = this.Definition.NbFrames.X - 1;
                            this.CurrentFrame.Y = this.Definition.NbFrames.Y - 1;
                            this.FinishedAnimation = true;
                        }
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var width = (int)(this.Definition.FrameSize.X * Definition.Scale.X);
            var height = (int)(this.Definition.FrameSize.Y * Definition.Scale.Y);
            spriteBatch.Draw(this._spriteSheet,
                          new Rectangle((int)(this.Position.X - width * 0.5), (int)(this.Position.Y - height * 0.5), width, height),
                          new Rectangle(this.CurrentFrame.X * this.Definition.FrameSize.X, this.CurrentFrame.Y * this.Definition.FrameSize.Y, this.Definition.FrameSize.X, this.Definition.FrameSize.Y),
                          Color.White);

        }
    }
}
