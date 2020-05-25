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

            /** Basic circuit **/

            //Inputs
            Node input1 = new In() { Output = true, Name = "In 1" };
            Node input2 = new In() { Output = false, Name = "In 2" };


            //Adder
            Node not1 = new Not() { Name = "Not 1" };
            Node or1 = new Or() { Name = "Or 1" };

            Node and1 = new And() { Name = "And 1" };
            Node nor1 = new Nor() { Name = "Nor 1" };


            //Outputs
            Node output1 = new Out() { Name = "Out 1" };
            Node output2 = new Out() { Name = "Out 2" };

            //Edges

            input1.OutputList.Add(new Edge(input1, not1));
            not1.NrOfInputs = 1;

            input1.OutputList.Add(new Edge(input1, or1));
            input2.OutputList.Add(new Edge(input2, or1));
            or1.NrOfInputs = 2;

            not1.OutputList.Add(new Edge(not1, and1));
            or1.OutputList.Add(new Edge(or1, and1));
            and1.NrOfInputs = 2;

            not1.OutputList.Add(new Edge(not1, nor1));
            or1.OutputList.Add(new Edge(or1, nor1));
            nor1.NrOfInputs = 2;

            nor1.OutputList.Add(new Edge(nor1, output1));
            and1.OutputList.Add(new Edge(and1, output2));

            output2.NrOfInputs = 1;
            output1.NrOfInputs = 1;


            Circuit circuit = new Circuit();
            //add nodes to circuit
          
            circuit.Components.Add(input1);
            circuit.Components.Add(input2);
            circuit.Components.Add(not1);
            circuit.Components.Add(or1);
            circuit.Components.Add(and1);
            circuit.Components.Add(nor1);
            circuit.Components.Add(output1);
            circuit.Components.Add(output2);

            try
            {
                circuit.Run(displayer);
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("ended");



            Console.Read();
        }
    }
}
