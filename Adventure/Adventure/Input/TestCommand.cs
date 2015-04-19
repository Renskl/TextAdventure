using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Input
{
    class TestCommand : Command
    {
        public override void execute()
        {
            Logger.Log(Logger.Severity.LOGMESSAGE, "Input on TestCommand received");
        }
    }
}
