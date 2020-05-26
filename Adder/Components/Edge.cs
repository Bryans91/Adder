using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components
{
    public class Edge
    {
        public Component In { get; set; }
        public Component Out { get; set; }

        public Edge(Component nodeIn, Component nodeOut)
        {
            In = nodeIn;
            Out = nodeOut;
        }

    }
}
