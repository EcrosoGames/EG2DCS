using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Animation
{
    public abstract class BaseAnimation
    {
        public abstract void Update(ref Rectangle rectangle);

        public virtual void Draw(Rectangle rectangle)
        {

        }

        public abstract bool IsComplete();
    }
}
