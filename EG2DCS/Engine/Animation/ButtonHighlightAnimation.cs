using EG2DCS.Engine.Widgets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Animation
{
    public class ButtonHighlightAnimation : BaseAnimation
    {
        private float step;
        private int timer = 0;
        private int time;

        public ButtonHighlightAnimation(Animator animator, int time)
        {
            step = animator.Rectangle.Width / (float)time;
            this.time = time;
        }

        public override void Update(Animator animator)
        {
            if (animator.GetType() != typeof(Button) || Complete)
                return;

            Button button = (Button)animator;

            button.highlightWidth = Math.Min(button.highlightWidth + step, button.Rectangle.Width);

            this.timer++;

            if (timer == time)
            {
                Complete = true;
            }
        }
    }
}
