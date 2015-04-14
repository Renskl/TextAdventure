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
			switch (Command) {
			case EKeys.UP:
				Console.WriteLine ("hallo omhoog");
				break;
			}
        }

        public void Render()
        {

        }
	}
}

