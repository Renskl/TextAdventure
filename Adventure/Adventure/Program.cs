#define DEBUG
#define KEYBOARD_INPUT

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

        //TMP
        public static Sprite spr;
        [STAThread]
        public static void Main(string[] args)
        {
#if (DEBUG)
            Logger.Log(Logger.Severity.LOGMESSAGE, "Automaton2D (c) 2015. Developed by Matthias Calis and Rens Kloosterhuis using OpenTK 1.1");
#endif 
            window = new GameWindow(Properties.Settings.Default.Width, Properties.Settings.Default.Height);
            GL.Viewport(0, 0, window.Width, window.Height); 
            window.Load += Load;
            window.RenderFrame += RenderFrame;
            window.UpdateFrame += UpdateFrame;
            window.Closing += Cleanup;
            window.Resize += Resize;
#if (DEBUG)
            Logger.Log(Logger.Severity.LOGMESSAGE, "Window created, window event delegates coupled...");
#endif
            spr = new Sprite(new Entity.Position(0, 0), new Entity.Size(64,64), "D:\\Applications\\Dropbox\\Photos\\Tiles\\red.png");
            window.Run(Properties.Settings.Default.DefaultUpdateRate, Properties.Settings.Default.DefaultFramerate);
        }

        private static void Load(Object Sender, EventArgs e)
        {
            window.VSync = VSyncMode.On;
        }

        private static void UpdateFrame(Object sender, FrameEventArgs e)
        {

        }

        private static void RenderFrame(Object sender, FrameEventArgs e)
        {
            // render graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, window.Width, 0, window.Height, 0.0, 4.0);

            // Sprites should be rendered here...essentially everything that
            // needs EnableClientState(VertexArray)

            spr.Render();

            GL.DisableClientState(ArrayCap.VertexArray);

            window.SwapBuffers();
        }

        private static void Resize(Object sender, EventArgs e)
        {

        }

        private static void Cleanup(Object Sender, EventArgs e)
        {
            spr.Cleanup();
        }
    }
}
