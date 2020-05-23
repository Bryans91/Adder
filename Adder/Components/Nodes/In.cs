using Adder.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components.Nodes
{
    public class In : Node
    {


        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
