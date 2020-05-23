using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG2DCS.Engine.Screen_Manager
{
   public abstract class BaseScreen
    {
        public string Name;
        public ScreenState State;
        public ScreenState LastState;
        public float Position;
        public bool Focused;
        public bool GrabFocus;
        public bool Overridable;
        public virtual void HandleInput()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void Draw()
        {

        }
        public virtual void Remove()
        {
            State = ScreenState.Shutdown;
        }
    }
}
