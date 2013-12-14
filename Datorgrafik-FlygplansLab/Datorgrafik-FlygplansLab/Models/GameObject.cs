using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Datorgrafik_FlygplansLab
{
    public abstract class GameObject
    {

        protected List<GameObject> children = new List<GameObject>();

        public virtual void Draw(BasicEffect effect)
        {
            foreach (GameObject child in children)
            {
                child.Draw(effect);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject child in children)
            {
                child.Update(gameTime);
            }
        }

    }
}
