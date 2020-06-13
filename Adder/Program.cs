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


            try {
                circuit.Run(new Connections());
                circuit.Run(new Cleaner());
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
