using EG2DCS.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EG2DCS.Engine.Add_Ons
{
    class DrawLive
    {
        public static RenderTarget2D Scren;
        public static GraphicsDeviceManager freedraw;
        public static SpriteBatch livedraw;
        public static Texture2D permGFX;

        public static void Send(Texture2D tex)
        {
            freedraw = Universal.Graphics;
            Scren = new RenderTarget2D(freedraw.GraphicsDevice, tex.Width, tex.Height);
            freedraw.GraphicsDevice.SetRenderTarget(Scren);
            livedraw = new SpriteBatch(freedraw.GraphicsDevice);
            livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            livedraw.Draw(tex, new Rectangle(0, 0, tex.Width, tex.Height), new Color(255, 255, 255));
            livedraw.End();
        }

        public static void Modify(Texture2D tex, Rectangle Drawto, Rectangle Drawfrom, Color col)
        {
            livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
            livedraw.Draw(tex, Drawto, Drawfrom, col);
            livedraw.End();
        }
        public static Texture2D Retrieve()
        {
            freedraw.GraphicsDevice.SetRenderTarget(null);
            Color[] col = new Color[Scren.Width * Scren.Height - 1];
            Scren.GetData(col);
            permGFX = new Texture2D(Universal.Graphics.GraphicsDevice, Scren.Width, Scren.Height);
            permGFX.SetData(col);
            Scren.Dispose();
            livedraw.Dispose();
            return permGFX;
        }
        public static Texture2D Transparancy(Texture2D td2, Color col)
        {
            Color[] colo = new Color[Scren.Width * Scren.Height - 1];
            td2.GetData(colo);
            for (int q = 0; q < colo.Length - 1; q++)
            {
                if (colo[q] == col)
                {
                    colo[q] = Color.Transparent; 
                }
            }
            td2.SetData(colo);
            return td2;
        }
    }
}
