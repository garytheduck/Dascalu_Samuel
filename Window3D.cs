using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obiecte3DOpenTK
{
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        MouseState previousMouse;
        Randomizer rando;
        Color4 default_bkgColor = Color4.LightBlue;
        private Triangle3D firstTriangle;
        private Point3D firstPoint;
        private Cub cb, cbsecondary;
        private Camera3Disometric camera;
        private Axes ax;
        private Grid grid;

        private List<Objectoid> rainOfObjects;
        private bool GRAVITY = true;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            displayHelp();

            rando = new Randomizer();
            firstTriangle = new Triangle3D(rando);
            firstPoint = new Point3D(rando);
            cb = new Cub("cub.txt");
            cbsecondary = new Cub("cub.txt");
            ax = new Axes();
            camera = new Camera3Disometric();
            grid = new Grid();
            rainOfObjects = new List<Objectoid>();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(default_bkgColor);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //setare perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //setare camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            camera.SetCamera();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //COD LOGICA
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            ax.Show();
            grid.Show();

            if(thisKeyboard[Key.Escape])
            {
                Exit();
            }
            if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                displayHelp();
            }
            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.getRandomColor());
            }
            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])    
            {
                GL.ClearColor(default_bkgColor);
            }
            if (thisKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                firstTriangle.ToggleVisibility();
            }
            if (thisKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                firstTriangle.DiscoMode();
            }


            //MISCARE CUB

            cb.CheckJump();
            if (thisKeyboard[Key.Space])
            {
                cb.Jump();
            }

            if (thisKeyboard[Key.W])
            {
                cb.MoveUp();
            }
            else if (thisKeyboard[Key.S])
            {
                cb.MoveDown();
            }

            if (thisKeyboard[Key.A])
            {
                cb.MoveLeft();
            }
            else if (thisKeyboard[Key.D])
            {
                cb.MoveRight();
            }
            
            if (thisKeyboard[Key.C])
            {
                camera.SetFirstPerson();
            }
            
            camera.FollowCube(cb.GetCoords(), new Vector3((thisMouse.X - Width / 2f) / (Width / 16f), (thisMouse.Y - Height / 2f) / (Height / 16f), 35));

            if (thisMouse[MouseButton.Left])
            {
                cbsecondary.StartFalling();
            }
            

            //OBJECT SPAWN       
            
            if (thisMouse[MouseButton.Right] && !previousMouse[MouseButton.Right])
            {
                Objectoid objectoid = new Objectoid(GRAVITY);
                rainOfObjects.Add(objectoid);
            
            }

            //UPDATE FALLING LOGIC
            foreach(Objectoid obj in rainOfObjects)
            {
                obj.UpdatePosition(GRAVITY);
            }
            //SWITCH GRAVITY
            if(thisKeyboard[Key.G] && !previousKeyboard[Key.G])
            {
                GRAVITY = !GRAVITY;
            }
            //OBJECT CLEANUP
            if(thisMouse[MouseButton.Left] && !previousMouse[MouseButton.Left])
            {
                rainOfObjects.Clear();
            }

            previousKeyboard = thisKeyboard;
            previousMouse = thisMouse;
        }

        private void displayHelp()
        {

            Console.WriteLine("     MENIU");
            Console.WriteLine("ESC - EXIT");
            Console.WriteLine("H - MENIU AJUTOR");
            Console.WriteLine("R - RESETARE PARAMETRI");
            Console.WriteLine("B - Schimbare BACKGROUNG RANDOMIZAT");
            Console.WriteLine("V - AFISAEAZA SAU ASCUNDE TRIUNGHI");
            Console.WriteLine("X - DISCO MODE");
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //RENDER CODE
            firstPoint.DrawPoint3D();
            cb.Draw();
            ax.Draw();
            grid.Draw();
            firstTriangle.Draw();

            cbsecondary.FallExample();
                foreach (Objectoid obj in rainOfObjects)
                {
                    obj.Draw();
                }

            //RENDER CODE

            SwapBuffers();
        }
    }
}
