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
        private const int XYZ_SIZE = 75;

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
        /// CERINTA 1 : Afisarea anti-orara a axelor, cu un singur GL.Begin().
        /// </summary>
        public void Draw()
        {
            if (AxesVisibility)
            {
                GL.LineWidth(1.0f);

                //Testare pointSize
                GL.PointSize(200.0f);
                GL.Begin(PrimitiveType.Points);
                GL.Color3(Color.Black);
                GL.Vertex3(10, 10, 5);
                GL.End();


                //GRADIENT
                GL.Begin(PrimitiveType.TriangleStrip);
                GL.Color3(Color.Black);
                GL.Vertex3(0, 0, 0);
                GL.Color3(Color.Yellow);
                GL.Vertex3(10, 10, 0);
                GL.Color3(Color.Green);

                GL.Vertex3(30, 40, 0);

                GL.End();

                GL.Begin(PrimitiveType.Lines);

                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(XYZ_SIZE, 0, 0);

                // Desenează axa Oy (cu galben).
                GL.Color3(Color.Yellow);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, XYZ_SIZE, 0); ;

                // Desenează axa Oz (cu verde).
                GL.Color3(Color.Green);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, XYZ_SIZE);
                GL.End();
            }

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
