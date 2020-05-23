using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Builders
{
    interface IBuilder
    {
        void BuildEdges();
        void BuildGridNodes();
        void BuildInputNodes();
        void BuildOutputNodes();
    }
}
