using System;
using System.Collections.Generic;

namespace Adventure
{
	class Program
	{
        public static bool isRunning = true;
        public static EKeys command;
        public static List<IUpdate> updateables = new List<IUpdate>();

        public static void Main (string[] args)
		{
            while (isRunning)
            {
                Update(Input());
                Render();
            }
		}

        private static EKeys Input()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            command = EKeys.NONE;
            if (cki.Key == ConsoleKey.UpArrow)
            {
                command = EKeys.UP;
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                command = EKeys.DOWN;
            }
            if (cki.Key == ConsoleKey.Enter)
            {
                command = EKeys.CONFIRM;
            }
            if (cki.Key == ConsoleKey.Escape)
            {
                command = EKeys.CANCEL;
            }
            return command;
        }

        private static void Update(EKeys Command)
        {
            foreach (IUpdate u in updateables)
            {
                u.Update(Command);
            }
            Console.WriteLine(Command);
        }

        private static void Render()
        {

        }

        public static void Register(IUpdate updateable)
        {
            updateables.Add(updateable);
        }
	}
}
