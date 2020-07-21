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
        private bool complete = false;
        private int timer = 0;
        private int time;

        private Action onComplete;

        public MoveAnimation(Vector2 from, Vector2 to, int time, Action onComplete)
        {
            step = (from - to) / time;
            this.time = time;
            this.onComplete = onComplete;
        }

        public override bool IsComplete()
        {
            return complete;
        }

        public override void Update(ref Rectangle rectangle)
        {
            rectangle.X += (int)step.X;
            rectangle.Y += (int)step.Y;

            this.timer++;

            if (timer == time)
            {
                complete = true;
                onComplete.Invoke();
            }
        }
    }
}
