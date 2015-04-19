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
#if (KEYBOARD_INPUT)
            window.KeyUp += KeyUp;
            window.KeyDown += KeyDown;
            window.KeyPress += KeyPress;
#endif
           
#if (DEBUG)
            Logger.Log(Logger.Severity.LOGMESSAGE, "Window created, window event delegates coupled...");
#endif
            spr = new Sprite(new Entity.Position(0, 0), new Entity.Size(64,64), "Assets\\red.png");
            window.Run(Properties.Settings.Default.DefaultUpdateRate, Properties.Settings.Default.DefaultFramerate);
        }

        private static void Load(Object Sender, EventArgs e)
        {
            window.VSync = VSyncMode.On;
            /***
             * We're not changing the Projection anywhere else, so we
             * only need to set the state once.
             * ***/
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, window.Width, 0, window.Height, 0.0, 4.0);
            Input.InputManager.AssignCommand(Input.InputManager.Action.MOVE_LEFT, new Input.TestCommand());
        }

        private static void UpdateFrame(Object sender, FrameEventArgs e)
        {
            var mouse = Mouse.GetState();
            if (mouse[MouseButton.Left])
            {
                Logger.Log(Logger.Severity.LOGMESSAGE, "Left press!");
            }
            else if (mouse[MouseButton.Right])
            {
                Logger.Log(Logger.Severity.LOGMESSAGE, "Right press!");
            }            
        }

        private static void RenderFrame(Object sender, FrameEventArgs e)
        {
            // render graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.EnableClientState(ArrayCap.VertexArray);


            // Sprites should be rendered here...essentially everything that
            // needs EnableClientState(VertexArray)

            // Also, think about Batching sprites. 
            // Binding and re-binding textures is expensive so all matching TextureId's should be lumped together to make the best use of Texture binding
            spr.Render();

            GL.DisableClientState(ArrayCap.VertexArray);

            window.SwapBuffers();
        }

        private static void Resize(Object sender, EventArgs e)
        {

        }

#if (KEYBOARD_INPUT)
        private static void Cleanup(Object Sender, EventArgs e)
        {
            spr.Cleanup();
        }

        private static void KeyUp(Object Sender, KeyboardKeyEventArgs e)
        {

        }

        private static void KeyDown(Object Sender, KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    spr.Translate(0.0f, 5.0f);
                    break;
                case Key.Down:
                    spr.Translate(0.0f, -5.0f);
                    break;
                case Key.Left:
                    spr.Translate(5.0f, 0.0f);
                    break;
                case Key.Right:
                    spr.Translate(-5.0f, 0.0f);
                    break;
                default:
                    break;
            }
        }
#endif
        private static void KeyPress(Object Sender, KeyPressEventArgs e)
        {

        }
    }
}
