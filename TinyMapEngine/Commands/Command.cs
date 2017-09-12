using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyMapEngine.Commands
{
    public class Command
    {
        public virtual void Do() { }
        public virtual void Undo() { }
    }
}
