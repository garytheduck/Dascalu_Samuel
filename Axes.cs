using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    class Axes
    {
        private bool AxesVisibility;

        private const int AXIS_LENGTH = 75;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Axes()
        {
            AxesVisibility = true;
        }

        /// <summary>
        /// This methods handles the drawing of the object. Must be called - always - from OnRenderFrame() method! The drawing can be unconditional.
        /// </summary>
        public void Draw()
        {
            if (AxesVisibility)
            {
                GL.LineWidth(1.0f);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(AXIS_LENGTH, 0, 0);
                GL.Color3(Color.ForestGreen);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, AXIS_LENGTH, 0);
                GL.Color3(Color.RoyalBlue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, AXIS_LENGTH);
                GL.End();
            }
        }

        /// <summary>
        /// Sets GridVisibility of the object ON.
        /// </summary>
        public void Show()
        {
            AxesVisibility = true;
        }

        /// <summary>
        /// Sets GridVisibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            AxesVisibility = false;
        }

        /// <summary>
        /// Toggles the AxesVisibility of the object. Once triggered, the attribute is applied automatically on drawing.
        /// </summary>
        public void ToggleVisibility()
        {
            AxesVisibility = !AxesVisibility;
        }
    }
}
