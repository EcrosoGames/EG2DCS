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
        protected bool complete = false;

        public abstract void Update(Animator animator);

        public virtual void Draw(Animator animator)
        {

        }

        public virtual bool IsComplete()
        {
            return complete;
        }

        public void SetComplete()
        {
            complete = true;
        }
    }
}
