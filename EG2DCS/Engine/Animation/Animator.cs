using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Animation
{
    public class Animator
    {
        private List<BaseAnimation> animations = new List<BaseAnimation>();
        
        public Rectangle rectangle;

        public Animator(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        public virtual void Update()
        {
            for (int i = animations.Count - 1; i >= 0; i--)
            {
                animations[i].Update(this);
                if (animations[i].IsComplete())
                {
                    animations.RemoveAt(i);
                }
            }
        }

        public void AddAnimation(BaseAnimation animation)
        {
            animations.Add(animation);
        }
    }
}
