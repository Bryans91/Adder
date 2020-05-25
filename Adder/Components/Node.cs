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
        public override void Run(IVisitor visitor)
        {
            Handle(); //Do node action

            base.Run(visitor);

            //pass Data on
            if (IsResolveable())
            {
                OutputList.ForEach((Edge edge) =>
                {
                    edge.Out.InputList.Add(Output);
                    if(edge.Out.IsResolveable())
                    {
                        edge.Out.Run(visitor);
                    }
                });
            }
            

        }

        public virtual void Handle()
        {
            //Do something here? 
        }



        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public abstract Node Clone();

    }
}
