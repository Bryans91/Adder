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
            //int max = visited.InputNodes.Count + visited.OutputNodes.Count + visited.AdderNodes.Count;
            //visited.InputNodes.ForEach((Node node) =>
            //{
            //    if(IsInfinite(node,0,max))
            //    {
            //        throw new Exception("The circuit contains an infinite loop.");
            //    }
            //});
        }

        public void Visit(Node visited)
        {
            HasCorrectNumberOfInputNodes(visited);
        }

        public void Visit(In visited)
        {
            if(!HasNext(visited))
            {
                throw new Exception("Input has no endpoint");
            }
        }

        public void Visit(Out visited)
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
            if (node.InputList.Count > 0)
            {
                if (node.NrOfInputs != node.InputList.Count)
                {
                    throw new Exception(node.Name + " Does not have enough input Nodes. Has:" + node.InputList.Count + " Requires:" + node.NrOfInputs);
                }
            } else {
                throw new Exception(node.Name + " Does not have any inputs.");
            }
        }

        private bool HasNext(Node node)
        {
            return node.OutputList.Count != 0;
        }


        private bool IsInfinite(Component node, int depth , int max)
        {
            foreach(Edge edge in node.OutputList)
            {
                if(depth > max)
                {
                    return true;
                }

                return IsInfinite(edge.Out, depth+1, max);
            }
            return false;
        }
       
    }
}
