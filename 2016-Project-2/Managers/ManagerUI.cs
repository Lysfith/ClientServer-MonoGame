using _2016_Project_2.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Managers
{
    public class ManagerUI
    {
        private static ManagerUI _instance;

        public static ManagerUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerUI();
                }
                return _instance;
            }
        }

        public List<UIBaseElement> _items { get; set; }
        public List<UIBaseElement> _itemsToDraw { get; set; }

        public ManagerUI()
        {
            _items = new List<UIBaseElement>();
            _itemsToDraw = new List<UIBaseElement>();
        }

        public void Clear()
        {
            _items.Clear();
            _itemsToDraw.Clear();
        }

        public void AddItem(UIBaseElement item)
        {
            _items.Add(item);
            _itemsToDraw.Add(item);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in _items)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _items.Clear();
            foreach (var item in _itemsToDraw)
            {
                item.Draw(gameTime, spriteBatch);
                _items.Add(item);
            }
        }

        public void Item_GainFocus(object sender, EventArgs e)
        {
            var parent = ((UIBaseElement)sender).GetFirstParent();

            _itemsToDraw.Remove(parent);
            _itemsToDraw.Add(parent);
        }
    }
}
