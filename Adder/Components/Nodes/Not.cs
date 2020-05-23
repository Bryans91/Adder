using Adder.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components.Nodes
{
    public class Not : Node
    {
        public override void Handle()
        {
            Output = true;

            InputList.ForEach((bool input) =>
            {
                if (input)
                {
                    Output = false;
                }
            });


            base.Handle();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
