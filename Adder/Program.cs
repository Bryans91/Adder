using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components;
using Adder.Visitors;
using Adder.Components.Nodes;
using Adder.IO;
using Adder.Factories;

namespace Adder
{
    class Program
    {
        static void Main(string[] args)
        {

            FileParser fp = new FileParser();
            Circuit circuit = fp.ParseCircuit("test.txt");

            //NodeFactory nf = NodeFactory.GetInstance();

            //nf.Create();
            /** Basic circuit **/
            //Adder
            //Node not1 = new Not() { Name = "Not 1" };
            //Node or1 = new Or() { Name = "Or 1" };

            //Node and1 = new And() { Name = "And 1" };
            //Node nor1 = new Nor() { Name = "Nor 1" };
     
            //bool input1 = false;
            //bool input2 = true;
       
            //Inputs
            //not1.AddDefaultInputs(input1); 
   
            //or1.AddDefaultInputs(input1);
            //or1.AddDefaultInputs(input2);

            //Edges

            //endpoint AND
            //not1.AddOutput(and1);
            //or1.AddOutput(and1);

            //endpoint NOR
            //not1.AddOutput(nor1);
            //or1.AddOutput(nor1);


            //create infinite loop
            //TODO: Fix check issue
            //WORKS FOR INFINITE: or1.OutputList.Add(new Edge(or1, not1));
            //DOES NOT WORK FOR INFINITE or1.AddOutput(not1); gooit geen error maar gaat ook niet fout
           // or1.AddOutput(not1);

            //Circuit circuit = new Circuit() { Name = "Circuit 1" };
            //circuit.Components.Add(not1);
            //circuit.Components.Add(or1);
            //circuit.Components.Add(and1);
            //circuit.Components.Add(nor1);
            // add this to detect the infinite, also infinite when not infinite
            //circuit.Components.Add(not1);



            try {
                circuit.Run(new Validator());
                circuit.Run(new Cleaner());
                circuit.Run(new Displayer());
                circuit.PrintTime();
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("ended");



            Console.Read();
        }
    }
}
