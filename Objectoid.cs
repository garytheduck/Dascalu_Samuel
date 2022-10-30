﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    //Acesta este un obiect care va cadea sub indluenta gravitatiei in interiorul programului.
    class Objectoid
    {
        private bool visibility;
        private bool isGravityBound;
        private Color color;
        private List<Vector3> coordList;
        private Randomizer rando;

        private const int GRAVITY_OFFSET = 1;

        //CONSTRUCTOR (INITIALIZARI)

        public Objectoid(bool gravity_status)
        {
            rando = new Randomizer();
            visibility = true;
            isGravityBound = gravity_status;
            color = rando.getRandomColor();
            
            coordList = new List<Vector3>();
            int size_offset = rando.GetRandomOffset(5, 10);  //DIMENSIUNE RANDOM
            int height_offset = rando.GetRandomOffset(10, 60); //Obiecte plasate la inaltime random
            int radial_offset = rando.GetRandomOffset(0, 15); //Obiecte plasate pe directia Ox - Oz 

            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(1 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 1 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));

        }
        public void Draw()
        {
            if (visibility)
            {
                GL.Color3(color);
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (Vector3 v in coordList)
                    GL.Vertex3(v);
                GL.End();
            }

        }
        public void UpdatePosition(bool gravity_status)
        {
            if(visibility && gravity_status && !GroundCollisionDetection())
            {
                for(int i = 0; i < coordList.Count; i++)
                {
                    coordList[i] = new Vector3(coordList[i].X, coordList[i].Y-GRAVITY_OFFSET, coordList[i].Z);
                }
            }
        }
        public bool GroundCollisionDetection()
        {
            foreach(Vector3 v in coordList)
            {
                if(v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }
    }
}
