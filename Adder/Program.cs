using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components;
using Adder.Visitors;
using Adder.Components.Nodes;

namespace Adder
{
    class Program
    {
        static void Main(string[] args)
        {

            IVisitor validator = new Validator();
            IVisitor displayer = new Displayer();

            Node and = new And();
            and.Name = "And 1";

            Node andTwo = new And();
            andTwo.Name = "And 2";


            Edge edge = new Edge(and, andTwo);
            and.OutputList.Add(edge);

            and.InputList.Add(true);
            and.InputList.Add(true);
            and.NrOfInputs = 2;

            and.Run(displayer);

            andTwo.NrOfInputs = 2;
            andTwo.Run(displayer);


            Console.Read();
        }
    }
}
