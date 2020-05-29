using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Adder.Factories;
using Adder.Components;
using Adder.Builders;

namespace Adder.IO
{
    public class FileParser
    {

        public bool A = false;
        public bool B = false;
        public bool Cin = false;
        IDictionary<string, Node> NodeDictionairy = new Dictionary<string, Node>();
        Circuit circuit;

        public Circuit ParseCircuit(String filePath)
        {
            FileReader fr = new FileReader(filePath);
            Boolean readingEdges = false;
            List<String> lines = fr.GetLines();

            if (lines != null)
            {

                circuit = new Circuit() { Name = "Circuit 1" };

                foreach (String line in lines)
                {
                    if (line.Equals("# Description of all the edges"))
                    {
                        readingEdges = true;
                    }
                    if ( ! line.StartsWith("#") && !String.IsNullOrEmpty(line))
                    {
                        if (line.Contains(":") && line.EndsWith(";"))
                        {
                            String[] circuitParts = GetCircuitParts(line);
                            if (readingEdges)
                            {
                                AddEdges(circuitParts);
                            }
                            else
                            {
                                Node node = AddNode(circuitParts);
                                if (node != null)
                                {
                                    NodeDictionairy[node.Name] = node;
                                }
                            }
                        }
                    }
                }

                return circuit;
            }

            return null;
        }

        private Node AddNode(String[] nodeParts)
        {
            if ( ! nodeParts[1].Contains("INPUT") && ! nodeParts[1].Contains("PROBE"))
            {
                Builder nodeBuilder = new Builder(nodeParts[1]);
                nodeBuilder.setName(nodeParts[0]);

                return nodeBuilder.Result();
            }
            if (nodeParts[1].Contains("INPUT"))
            {
                switch(nodeParts[0])
                {
                    case "A":
                        A = nodeParts[1].Contains("HIGH") ? true : false;
                        break;
                    case "B":
                        B = nodeParts[1].Contains("HIGH") ? true : false;
                        break;
                    case "Cin":
                        Cin = nodeParts[1].Contains("HIGH") ? true : false;
                        break;
                }
            }

            return null;
        }

        private void AddEdges(String[] edgeParts)
        {

            bool inputType = false;
            bool input = false;

            if ( ! edgeParts[0].StartsWith("NODE"))
            {
                inputType = true;

                switch (edgeParts[0])
                {
                    case "A":
                        input = A;
                        break;
                    case "B":
                        input = B;
                        break;
                    case "Cin":
                        input = Cin;
                        break;
                }
            }

            foreach(String edgePart in edgeParts.Skip(1))
            {
                if (edgePart.StartsWith("NODE"))
                {
                    if(inputType)
                    {
                        NodeDictionairy[edgePart].AddDefaultInputs(input);
                    }
                    else
                    {
                        NodeDictionairy[edgeParts[0]].AddOutput(NodeDictionairy[edgePart]);
                    }
                }
            }

            if (!inputType)
            {
                circuit.Components.Add(NodeDictionairy[edgeParts[0]]);
            }

        }

        private String[] GetCircuitParts(String line)
        {
            String pattern = @"([a-zA-Z0-9_]+)";
            var result = Regex.Matches(line, pattern)
                .OfType<Match>()
                .Select(m => m.Groups[0].Value)
                .ToArray();

            return result;
        }
    }
}
