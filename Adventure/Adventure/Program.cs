using System;
using System.Drawing;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Adventure
{
    class Program
    {
        public static bool isRunning = true;
        public static GameWindow window;

        [STAThread]
        public static void Main(string[] args)
        {
            window = new GameWindow();
            GL.Viewport(0, 0, window.Width, window.Height);
            window.RenderFrame += RenderFrame;
            // Run the game at 60 updates per second
            window.Run(60.0);
        }

        private static void Load(Object Sender, FrameEventArgs e)
        {

        }

        private static void UpdateFrame(Object sender, FrameEventArgs e)
        {

            //test
        }

        private static void RenderFrame(Object sender, FrameEventArgs e)
        {
            // render graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            window.SwapBuffers();
        }

        private static void Resize(Object sender, FrameEventArgs e)
        {

        }
    }
}
