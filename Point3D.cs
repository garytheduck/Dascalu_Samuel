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
    class Point3D
    {
        private Vector3 position;
        private bool pointVisibility;
        private Color pointColor;
        private float size;
        public Point3D(Randomizer _r)
        {
            position = new Vector3(0,0,0);
            pointVisibility = true;
            pointColor = _r.getRandomColor();
            size = 10.0f;
        }
        public void ToggleVisibility()
        {
            pointVisibility = !pointVisibility;
        }
        public void EnlargePoint3D()
        {
            if(size == 10.0f)
            {
                size += 1.0f;
            }
            else
            {
                size = 10.0f;
            }
        }
        public void SmallPoint3D()
        {
            if (size == 10.0f)
            {
                size -= 1.0f;
            }
            else
            {
                size = 10.0f;
            }
        }
        public void DrawPoint3D()
        {
            GL.PointSize(size);
            GL.Begin(PrimitiveType.Points);
            GL.Color4(pointColor);
            GL.Vertex3(position);

            GL.End();
        }
    }
}
