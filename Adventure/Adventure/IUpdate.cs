using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    interface IUpdate
    {
        void Update(EKeys Command);
        void Render();
    }
}
