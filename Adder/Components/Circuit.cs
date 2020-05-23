using Adder.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components
{
    public class Circuit : Component //Composite
    {
        public List<Node> InputNodes { get; private set; } = new List<Node>();
        public List<Node> OutputNodes { get; private set; } = new List<Node>();
        public List<Node> AdderNodes { get; set; } = new List<Node>();

        public Circuit() : base()
        {
            InputNodes = new List<Node>();
            OutputNodes = new List<Node>();
            AdderNodes = new List<Node>();
        }

        public override void Run(IVisitor visitor)
        {
            base.Run(visitor);
        }


        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
