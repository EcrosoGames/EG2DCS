using EG2DCS.Engine.Globals;
using EG2DCS.Engine.Overlay;
using EG2DCS.Engine.Toast;
using EG2DCS.Engine.Widgets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace EG2DCS.Engine.Screen_Manager
{
    public abstract class BaseScreen
    {
        public string Name = "N/a";
        public ScreenState State;
        public ScreenState LastState;
        public float Position;
        public bool Focused;
        public bool GrabFocus;
        public bool Overridable = true;

        private List<BaseOverlay> Overlays { get; } = new List<BaseOverlay>();
        private List<BaseToast> Toasts { get; } = new List<BaseToast>();

        private List<Widget> Widgets { get; } = new List<Widget>();
        private List<Widget> Hovered { get; } = new List<Widget>();

        public virtual void HandleInput()
        {
            if (Overlays.Count > 0)
            {
                Overlays[0].HandleInput();
            }

            MouseState mouseState = Mouse.GetState();
            Point point = mouseState.Position;
            foreach (Widget widget in Widgets)
            {
                if (widget.rectangle.Contains(point) && !Hovered.Contains(widget))
                {
                    widget.OnHover();
                    Hovered.Add(widget);
                }
                else if (!widget.rectangle.Contains(point) && Hovered.Contains(widget))
                {
                    widget.OnUnHover();
                    Hovered.Remove(widget);
                }
            }
        }
        public virtual void Update()
        {
            for (int i = Overlays.Count - 1; i >= 0; i--)
            {
                Overlays[i].Update();
            }

            for (int i = Toasts.Count - 1; i >= 0; i--)
            {
                BaseToast toast = Toasts[i];
                toast.Update();
                if (toast.IsComplete())
                {
                    Toasts.RemoveAt(i);
                }
            }

            for (int i = Widgets.Count - 1; i >= 0; i--)
            {
                Widget widget = Widgets[i];
                widget.Update();
            }
        }
        public virtual void Draw()
        {
            Universal.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            for (int i = Overlays.Count - 1; i >= 0; i--)
            {
                Overlays[i].Draw();
            }
            Universal.SpriteBatch.End();

            Universal.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            for (int i = Toasts.Count - 1; i >= 0; i--)
            {
                Toasts[i].Draw();
            }
            Universal.SpriteBatch.End();

            Universal.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            for (int i = Widgets.Count - 1; i >= 0; i--)
            {
                Widgets[i].Draw();
            }
            Universal.SpriteBatch.End();
        }
        public virtual void Remove()
        {
            for (int i = Overlays.Count - 1; i >= 0; i--)
            {
                Overlays[i].Remove();
            }
            Overlays.Clear();
            for (int i = Toasts.Count - 1; i >= 0; i--)
            {
                Toasts[i].Remove();
            }
            Toasts.Clear();
            for (int i = Widgets.Count - 1; i >= 0; i--)
            {
                Widgets[i].Remove();
            }
            Widgets.Clear();
            State = ScreenState.Shutdown;
        }

        public virtual void OnClick(bool left, int x, int y)
        {
            Point point = new Point(x, y);
            foreach (Widget widget in Widgets)
            {
                if (widget.rectangle.Contains(point))
                {
                    widget.OnClick(left);
                }
            }
        }

        public virtual void OnUnClick(int x, int y)
        {

        }

        public void PushOverlay(BaseOverlay overlay)
        {
            Overlays.Insert(0, overlay);
        }

        public BaseOverlay PopOverlay()
        {
            if (Overlays.Count == 0)
                return null;

            BaseOverlay overlay = Overlays[0];
            Overlays.Remove(overlay);
            return overlay;
        }

        public void PushToast(BaseToast toast)
        {
            Toasts.Insert(0, toast);
            toast.Start();
        }

        public void AddWidget(Widget widget)
        {
            Widgets.Add(widget);
        }
    }
}
