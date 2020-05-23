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

            Circuit circuit = new Circuit();

            Node input1 = new In() { Output = true };
            Node input2 = new In() { Output = true };

            Edge edge = new Edge(input1, and);
            Edge edge2 = new Edge(input2, and);
            input1.OutputList.Add(edge);
            input2.OutputList.Add(edge2);


            circuit.InputNodes.Add(input1);
            circuit.InputNodes.Add(input2);
            circuit.AdderNodes.Add(and);


            //create infinite
            //Edge edge3 = new Edge(and, input1);
            //and.OutputList.Add(edge3);

            try
            {
                circuit.Run(validator);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("ended");



            Console.Read();
        }
    }
}
