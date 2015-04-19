using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Input
{
    class InputManager
    {
        public enum Action
        {
            MOVE_LEFT,
            MOVE_RIGHT,
            MOVE_UP,
            MOVE_DOWN
        }

        private static Dictionary<Action, Command> mappedCommands = new Dictionary<Action, Command>();

        public static readonly InputManager Instance = new InputManager();
        private Command[] commands;

        static InputManager() { }
        private InputManager() { }

        public static void AssignCommand(Action cmdAction, Command cmd)
        {
            if (!mappedCommands.ContainsKey(cmdAction))
            {
                mappedCommands.Add(cmdAction, cmd);
                Logger.Log(Logger.Severity.LOGMESSAGE, String.Format("Mapped action {0} to command {1}", cmdAction.ToString(), cmd.ToString()));
            }
            else
            {
                Logger.Log(Logger.Severity.WARNING, String.Format("Action {0} is already assigned", cmdAction.ToString()));
            }
        }
    }
}
