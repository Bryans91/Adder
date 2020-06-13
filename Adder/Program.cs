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
            Circuit circuit = fp.ParseCircuit("../../../Files/Circuit1_FullAdder.txt");
            //Circuit circuit = fp.ParseCircuit("../../../Files/Circuit4_InfiniteLoop.txt");

            //Node NODE1 = new Or() { Name = "NODE1" };
            //Node NODE2 = new And() { Name = "NODE2" };
            //Node NODE3 = new And() { Name = "NODE3" };
            //Node NODE4 = new Not() { Name = "NODE4" };
            //Node NODE5 = new And() { Name = "NODE5" };
            //Node NODE6 = new Or() { Name = "NODE6" };
            //Node NODE7 = new Not() { Name = "NODE7" };
            //Node NODE8 = new Not() { Name = "NODE8" };
            //Node NODE9 = new And() { Name = "NODE9" };
            //Node NODE10 = new And() { Name = "NODE10" };
            //Node NODE11 = new Or() { Name = "NODE11" };

            //bool t = true;
            //bool f = false;

            ////Inputs
            //// Cin
            //NODE3.AddDefaultInputs(f);
            //NODE7.AddDefaultInputs(f);
            //NODE10.AddDefaultInputs(f);
            //// A
            //NODE1.AddDefaultInputs(t);
            //NODE2.AddDefaultInputs(t);
            //// B
            //NODE1.AddDefaultInputs(t);
            //NODE2.AddDefaultInputs(t);

            ////Edges
            //NODE1.AddOutput(NODE3);
            //NODE1.AddOutput(NODE5);

            //NODE2.AddOutput(NODE4);
            //NODE2.AddOutput(NODE6);

            //NODE3.AddOutput(NODE6);

            //NODE4.AddOutput(NODE5);

            //NODE5.AddOutput(NODE8);
            //NODE5.AddOutput(NODE9);

            //NODE7.AddOutput(NODE9);

            //NODE8.AddOutput(NODE10);

            //NODE9.AddOutput(NODE11);

            //NODE10.AddOutput(NODE11);

            //Circuit circuit = new Circuit() { Name = "Circuit 1" };
            //circuit.Components.Add(NODE1);
            //circuit.Components.Add(NODE2);
            //circuit.Components.Add(NODE3);
            //circuit.Components.Add(NODE4);
            //circuit.Components.Add(NODE5);
            //circuit.Components.Add(NODE6);
            //circuit.Components.Add(NODE7);
            //circuit.Components.Add(NODE8);
            //circuit.Components.Add(NODE9);
            //circuit.Components.Add(NODE10);
            //circuit.Components.Add(NODE11);
            


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
