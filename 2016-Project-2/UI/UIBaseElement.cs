using _2016_Project_2.Managers;
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
    public class UIBaseElement : IDisposable
    {
        public Point Position { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public bool Initialized { get; set; }
        public bool HasFocus { get; set; }
        public bool HasHover { get; set; }
        public bool HasChildFocus { get; set; }

        public bool Enable { get; set; }
        public bool Visible { get; set; }

        public UIBaseElement Parent { get; set; }
        public List<UIBaseElement> Children { get; set; }

        public event EventHandler<EventArgs> OnHoverStart;
        public event EventHandler<EventArgs> OnHoverEnd;
        public event EventHandler<EventArgs> OnGainFocus;
        public event EventHandler<EventArgs> OnLostFocus;

        public UIBaseElement()
        {
            Enable = true;
            Visible = true;
            Children = new List<UIBaseElement>();
            Initialized = false;

            OnGainFocus += ManagerUI.Instance.Item_GainFocus;
        }

        public virtual void LoadContent(ContentManager content)
        {
            foreach(var child in Children)
            {
                child.LoadContent(content);
            }

            Initialized = true;
        }

        public virtual void Update(GameTime gameTime)
        {
            if(!Initialized && Enable)
            {
                LoadContent(MyGame.Instance.Content);
            }

            if (Enable && Visible)
            {

                var mouseState = Mouse.GetState();
                if (Position.X <= mouseState.X && mouseState.X < Position.X + Width
                    && Position.Y <= mouseState.Y && mouseState.Y < Position.Y + Height)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        HasFocus = true;
                        if (OnGainFocus != null)
                        {
                            OnGainFocus(this, null);
                        }
                    }
                    HasHover = true;
                    if (OnHoverStart != null)
                    {
                        OnHoverStart(this, null);
                    }
                }
                else
                {
                    if (HasFocus && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        HasFocus = false;

                        if (OnLostFocus != null)
                        {
                            OnLostFocus(this, null);
                        }
                    }

                    if (HasHover && OnHoverEnd != null)
                    {
                        OnHoverEnd(this, null);
                    }

                    HasHover = false;
                }

                foreach (var child in Children)
                {
                    child.Update(gameTime);
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Initialized && Enable)
            {
                LoadContent(MyGame.Instance.Content);
            }

            if (Enable && Visible)
            {
                foreach (var child in Children)
                {
                    child.Draw(gameTime, spriteBatch);
                }
            }

        }

        public void AddChild(UIBaseElement child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        public void RemoveChild(UIBaseElement child)
        {
            if (Children != null && Children.Contains(child))
            {
                Children.Remove(child);
            }
        }

        public UIBaseElement GetFirstParent()
        {
            if(Parent != null)
            {
                return Parent.GetFirstParent();
            }

            return this;
        }

        public void NextChild()
        {
            if (Children != null && Children.Any() && (HasFocus || HasChildFocus))
            {
                if(HasFocus)
                {
                    HasFocus = false;
                    HasChildFocus = true;
                    Children[0].HasFocus = true;
                }
                else if (HasChildFocus && Children.Count > 1)
                {
                    var itemFocused = Children.First(x => x.HasFocus);
                    var index = Children.IndexOf(itemFocused);
                    itemFocused.HasFocus = false;
                    HasChildFocus = true;
                    Children[0].HasFocus = true;
                }
            }
        }

        public virtual void Dispose()
        {
            OnGainFocus = null;
            OnHoverEnd = null;
            OnHoverStart = null;
            OnLostFocus = null;
        }

    }
}
