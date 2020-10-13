using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using System;

namespace EG2DCS.Engine.Toast
{
    public class BaseToast : Animator
    {
        public Color Color { get; set; } = Color.White;

        public int AnimationTime { get; set; } = 120;

        private int timer = 0;
        private bool delay = false;

        private Vector2 size;

        private Vector2 from;
        private Vector2 to;

        private bool complete = false;

        public BaseToast(Vector2 size) : base(new Rectangle())
        {
            this.size = size;
        }

        public virtual void Start()
        {
            from = new Vector2(Universal.GameSize.X + 50, 100);
            to = new Vector2((from.X - size.X) - 150, 100);

            Rectangle = new Rectangle((int)from.X, (int)from.Y, (int)size.X, (int)size.Y);
            base.AddAnimation(new MoveAnimation(to, from, AnimationTime, () =>
            {
                delay = true;
            }));
        }

        public override void Update()
        {
            base.Update();

            if (delay)
            {
                if (timer == 240)
                {
                    delay = false;
                    base.AddAnimation(new MoveAnimation(from, to, AnimationTime, () =>
                    {
                        complete = true;
                    }));
                }

                timer++;
            }
        }

        public virtual void Draw()
        {
            if (complete)
                return;

            Universal.SpriteBatch.Draw(Textures.Null, Rectangle, Color);
        }

        public virtual void Remove()
        {
            complete = true;
        }

        public bool IsComplete()
        {
            return this.complete;
        }
    }
}
