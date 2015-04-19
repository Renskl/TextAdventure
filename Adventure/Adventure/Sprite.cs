using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace Adventure
{
    class Sprite : Entity
    {

        private uint VertexBufferObjectHandle;
        private int TextureId;
        private float[] vertices;
        private float deltaX, deltaY;

        public Sprite(Position position, Size size, string filename) : base(position, size)
        {
            vertices = new float[] 
            {
                position.X, position.Y, 0,
                position.X + size.Width, position.Y, 0,
                position.X + size.Width, position.Y + size.Height, 0,
                position.X, position.Y + size.Height, 0
            };

            GL.GenBuffers(1, out VertexBufferObjectHandle);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObjectHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr) (vertices.Length * 8 * sizeof(float)), vertices, BufferUsageHint.StaticDraw);

            TextureId = TextureManager.LoadTexture(filename);
        }

        public override void Render()
        {
            /***
             * If the TextureId has been set to -1 by the TextureManager, the Bitmap has failed to load. As such, it should never attempt to render.
             * Or inversely, if the TextureId >= 0 we assume it is valid and will attempt to render.
             ***/
            if (TextureId >= 0)
            {

                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, TextureId);

                GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObjectHandle);
                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
               
                GL.DrawArrays(PrimitiveType.Quads, 0, vertices.Length);
                
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                //GL.PopMatrix();

                GL.Translate(new Vector3(deltaX, deltaY, 0.0f));
                deltaX = 0; deltaY = 0;
            }
        }

        public override void Update()
        {

        }

        public override void Cleanup()
        {
            GL.DeleteBuffer(VertexBufferObjectHandle);
        }

        public void Translate(float dx, float dy)
        {
            deltaX += dx;
            deltaY += dy;
        }
    }
}
