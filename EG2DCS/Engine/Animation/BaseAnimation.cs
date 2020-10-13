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
        public bool Complete { get; set; } = false;

        public abstract void Update(Animator animator);

        public virtual void Draw(Animator animator)
        {

        }
    }
}
