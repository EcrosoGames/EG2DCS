using EG2DCS.Engine.Animation;
using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using System;

namespace EG2DCS.Engine.Toast
{
    public class BaseToast : Animator
    {
        private Color color;

        private Rectangle rectangle;

        private int timer = 0;
        private bool delay = false;

        private Vector2 from;
        private Vector2 to;

        private bool complete = false;

        public virtual void Start()
        {
            color = new Color(Universal.rnd.Next(256), Universal.rnd.Next(256), Universal.rnd.Next(256), 255);

            from = new Vector2((Universal.GameSize.X / 2) - 250, Universal.GameSize.Y + 100);
            to = new Vector2(from.X, from.Y - 300);

            rectangle = new Rectangle((int)from.X, (int)from.Y, 500, 100);
            base.AddAnimation(new MoveAnimation(to, from, 120, () =>
            {
                delay = true;
            }));
        }

        public virtual void Update()
        {
            base.Update(ref rectangle);

            if (delay)
            {
                if (timer == 240)
                {
                    delay = false;
                    base.AddAnimation(new MoveAnimation(from, to, 120, () =>
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

            Universal.SpriteBatch.Draw(Textures.Null, rectangle, color);
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
