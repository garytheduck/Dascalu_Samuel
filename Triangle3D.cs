using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private bool visibility;
        private float lineWidth;
        private Randomizer localRando;
        
        public Triangle3D(Randomizer _r)
        {
            pointA = _r.Generate3DPoint();
            pointB = _r.Generate3DPoint();
            pointC = _r.Generate3DPoint();

            color = _r.getRandomColor();
            visibility = true;
            lineWidth = 1.0f;
            localRando = _r;
        }
        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Triangles);
                GL.Color4(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);

                GL.End();
            }

        }
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }
        public void DiscoMode()
        {
            color = localRando.getRandomColor();
        }
    }
}
