using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components;
using Adder.Components.Nodes;

namespace Adder.Visitors
{
    public class Validator : IVisitor
    {
        public void Visit(Component visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Circuit visited)
        {
            if (visited.Components.Count == 0)
            {
                throw new Exception("The circuit has no nodes.");
            }

        }

        public void Visit(Node visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

      
        public void Visit(And visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(Nand visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(Nor visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(Not visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(Or visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(Xor visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }


        private void HasCorrectNumberOfInputNodes(Node node)
        {


            if (IsInfinite(node))
            {
                throw new Exception("The circuit contains an infinite loop.");
            }
        }

        private bool HasNext(Node node)
        {
            return node.OutputList.Count != 0;
        }


        private bool IsInfinite(Component component)
        {
            if(component.NrOfInputs < component.InputList.Count)
            {
                return true;
            }
            return false;
        }
       
    }
}
