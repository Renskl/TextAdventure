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


        public static void Main(string[] args)
        {
            var game = new GameWindow();
            GL.Viewport(0, 0, game.Width, game.Height);
            game.RenderFrame += (sender, e) =>
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

                game.SwapBuffers();
            };
            // Run the game at 60 updates per second
            game.Run(60.0);
        }
    }
}
