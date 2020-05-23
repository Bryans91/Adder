using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Visitors;

namespace Adder.Components
{
    public abstract class Node : Component //Leaf
    {
      
        public List<bool> InputList { get; set; }
        public List<Edge> OutputList { get; set; }

        public string Name { get; set; }

        public bool Output { get; set; }


        public int NrOfInputs { get; set; }


        public Node() : base()
        {
            OutputList = new List<Edge>();
            InputList = new List<bool>();
            Output = false;
        }


        public override void Run(IVisitor visitor)
        {
            base.Run(visitor);
            Handle();
        }

        public virtual void Handle()
        {

            //stuur output naar edges
   
            if (NrOfInputs == InputList.Count)
            {
                OutputList.ForEach((Edge edge) =>
                {
                    edge.Out.InputList.Add(Output);
                });
            }
        }
   


        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public abstract Node Clone();

    }
}
