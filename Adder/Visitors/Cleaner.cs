using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components;
using Adder.Components.Nodes;

namespace Adder.Visitors
{
    public class Cleaner : IVisitor
    {
        public void Visit(Component visited)
        {
            ResetPrinted(visited);
        }

        public void Visit(Circuit visited)
        {
            ResetPrinted(visited);
        }

        public void Visit(Node visited)
        {
            ResetNode(visited);
        }

        public void Visit(And visited)
        {
            ResetNode(visited);
        }

        public void Visit(Nand visited)
        {
            ResetNode(visited);
        }

        public void Visit(Nor visited)
        {
            ResetNode(visited);
        }

        public void Visit(Not visited)
        {
            ResetNode(visited);
        }

        public void Visit(Or visited)
        {
            ResetNode(visited);
        }

        public void Visit(Xor visited)
        {
            ResetNode(visited);
        }

        private void ResetNode(Component component)
        {
            ResetPrinted(component);
            ResetInputs(component);
        }

        private void ResetPrinted(Component component)
        {
            component.Printed = false;
        }

        private void ResetInputs(Component component)
        {
            //TODO: Probleem oplossen, sommige inputs komen nergens vandaan / zijn default dus deze moeten niet gewist worden bij een cleanup

            component.InputList.Clear();
        }
    }
}
