﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D ex = new Window3D())
            {
                ex.Run(30.0, 0.0);
            }
        }
    }
}
