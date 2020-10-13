using EG2DCS.Engine.Widgets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Animation
{
    public class MoveAnimation : BaseAnimation
    {
        private Vector2 step;
        private int timer = 0;
        private int time;

        private Action onComplete;

        public MoveAnimation(Vector2 from, Vector2 to, int time, Action onComplete)
        {
            step = (from - to) / time;
            this.time = time;
            this.onComplete = onComplete;
        }

        public override void Update(Animator animator)
        {
            animator.Rectangle.X += (int)step.X;
            animator.Rectangle.Y += (int)step.Y;

            this.timer++;

            if (timer == time)
            {
                Complete = true;
                onComplete.Invoke();
            }
        }
    }
}
