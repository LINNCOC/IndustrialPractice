using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace industrialpractice.Common
{
    internal interface ITask
    {
        string Title { get; }
        string Description { get; }
        string[] Requirements { get; }
        void Run();
    }
}
