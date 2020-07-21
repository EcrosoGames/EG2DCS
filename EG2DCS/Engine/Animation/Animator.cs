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

        public void Update(ref Rectangle rectangle)
        {
            for (int i = animations.Count - 1; i >= 0; i--)
            {
                animations[i].Update(ref rectangle);
                if(animations[i].IsComplete())
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
