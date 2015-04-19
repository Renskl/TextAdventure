using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public abstract class Entity
    {
        public struct Position
        {
            public float X;
            public float Y;
            public Position(float x, float y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        public struct Size
        {
            public float Width;
            public float Height;
            public Size(float width, float height)
            {
                this.Width = width;
                this.Height = height;
            }
        }

        protected Position position;
        protected Size size;

        public Entity (Position p, Size s)
        {
            position = p;
            size = s;
        }

        public abstract void Render();
        public abstract void Update();
        public abstract void Cleanup();

    }
}
