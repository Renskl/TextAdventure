using System;
using System.Collections.Generic;

namespace Adventure
{
	public class Menu : IUpdate
	{
        private int selectedOption = 0;
        private List<String> options = new List<String>();

		public Menu (List<String> options)
		{
            this.options = options;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Program.Register(this);
		}

        public Menu() 
        {
            Program.Register(this);
        }

        public void Update(EKeys Command)
        {
			switch (Command) {
			case EKeys.UP:
                    if (selectedOption > 0)
                        selectedOption--;
				break;
            case EKeys.DOWN:
                    if (selectedOption < options.Count-1)
                        selectedOption++;
                break;
			}
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                if (selectedOption == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(options[i]);
            }
        }

        public void AddOption(string option)
        {
            this.options.Add(option);
        }
	}
}

