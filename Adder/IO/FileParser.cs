using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Adder.IO
{
    public class FileParser
    {

        public void ParseCircuit(String filePath)
        {
            FileReader fr = new FileReader(filePath);
            Boolean readingEdges = false;
            List<String> lines = fr.GetLines();

            if (lines != null)
            {
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
                                AddNode(circuitParts);
                            }
                        }
                    }
                }
            }
        }

        private void AddNode(String[] nodeParts)
        {
            Console.WriteLine(nodeParts[0] + " has the following output:");
            foreach(String part in nodeParts.Skip(1))
            {
                Console.WriteLine("- " + part);
            }
            Console.WriteLine("-------------------");
        }

        private void AddEdges(String[] edgeParts)
        {
            Console.WriteLine(edgeParts[0] + " has the following edges:");
            foreach (String part in edgeParts.Skip(1))
            {
                Console.WriteLine("- " + part);
            }
            Console.WriteLine("-------------------");
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
