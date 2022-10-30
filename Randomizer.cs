using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    class Randomizer
    {
        private const int MIN_VAL = -25;
        private const int MAX_VAL = 256;
        private Random r;
        public Randomizer()
        {
            r = new Random();
        }
        public int GetRandomOffset( int minval, int maxval)
        {
            int genInteger = r.Next(minval, maxval);

            return genInteger;
        }

        public Color getRandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);
            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }
        public Vector3 Generate3DPoint()
        {
            int a = r.Next(MIN_VAL, MAX_VAL);
            int b = r.Next(MIN_VAL, MAX_VAL);
            int c = r.Next(MIN_VAL, MAX_VAL);
            Vector3 vec = new Vector3(a, b, c);

            return vec;

        }
    }
}
