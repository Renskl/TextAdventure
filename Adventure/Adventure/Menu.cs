using System;

namespace Adventure
{
	public class Menu : IUpdate
	{
		public Menu ()
		{
            Program.Register(this);
		}

        public void Update(EKeys Command)
        {

        }

        public void Render()
        {

        }
	}
}

