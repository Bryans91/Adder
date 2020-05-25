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



            //Adder
            Node not1 = new Not() { Name = "Not 1" };
            Node or1 = new Or() { Name = "Or 1" };

            Node and1 = new And() { Name = "And 1" };
            Node nor1 = new Nor() { Name = "Nor 1" };



            //Edges

            bool input1 = true;
            bool input2 = false;

            not1.InputList.Add(input1); //input 1
            not1.NrOfInputs = 1;


            or1.InputList.Add(input1);
            or1.InputList.Add(input2);
            or1.NrOfInputs = 2;

            not1.OutputList.Add(new Edge(not1, and1));
            or1.OutputList.Add(new Edge(or1, and1));
            and1.NrOfInputs = 2;

            not1.OutputList.Add(new Edge(not1, nor1));
            or1.OutputList.Add(new Edge(or1, nor1));
            nor1.NrOfInputs = 2;




            Circuit circuit = new Circuit();
            //add nodes to circuit
   
            circuit.Components.Add(not1);
            circuit.Components.Add(or1);
            circuit.Components.Add(and1);
            circuit.Components.Add(nor1);

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
