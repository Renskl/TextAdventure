using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public sealed class Logger
    {
        public static readonly Logger Instance = new Logger();

        static Logger() { }
        private Logger() { }

        public enum Severity
        {
            LOGMESSAGE,
            WARNING,
            ERROR,
            FATALERROR
        }

        public static void Log(Severity severity, string message)
        {
            switch (severity)
            {
                case Severity.LOGMESSAGE:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(String.Format("[-] >> {0}", message));
                    break;
                case Severity.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(String.Format("[?] >> {0}", message));
                    break;
                case Severity.ERROR:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(String.Format("[!] >> {0}", message));
                    break;
                case Severity.FATALERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(String.Format("[!!!] >> {0}", message));
                    break;
                default:
                    break;
            }
        }
    }
}
