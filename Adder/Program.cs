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
            /** Basic circuit **/
            //Adder
            Node not1 = new Not() { Name = "Not 1" };
            Node or1 = new Or() { Name = "Or 1" };

            Node and1 = new And() { Name = "And 1" };
            Node nor1 = new Nor() { Name = "Nor 1" };
     
            bool input1 = true;
            bool input2 = false;
       
            //Edges
            not1.AddDefaultInputs(input1); //input 1
    
            or1.AddDefaultInputs(input1);
            or1.AddDefaultInputs(input2);


            //endpoint AND
            not1.AddOutput(and1);
            or1.AddOutput(and1);

            //endpoint NOR
            not1.AddOutput(nor1);
            or1.AddOutput(nor1);


            //create infinite loop
           // nor1.AddOutput(not1);
          
            Circuit circuit = new Circuit() { Name = "Circuit 1" };
            circuit.Components.Add(not1);
            circuit.Components.Add(or1);
            circuit.Components.Add(and1);
            circuit.Components.Add(nor1);

            try {
                circuit.Run(new Validator());
                circuit.Run(new Cleaner());
                circuit.Run(new Displayer());
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("ended");



            Console.Read();
        }
    }
}
