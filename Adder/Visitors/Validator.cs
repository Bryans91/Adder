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
            Console.WriteLine("this is a circuit");
            //throw new NotImplementedException();
        }

        public void Visit(Node visited)
        {
            Console.WriteLine("this is a node");
           // throw new NotImplementedException();
        }

        public void Visit(In visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Out visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(And visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Nand visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Nor visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Not visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Or visited)
        {
            throw new NotImplementedException();
        }

        public void Visit(Xor visited)
        {
            throw new NotImplementedException();
        }
    }
}
