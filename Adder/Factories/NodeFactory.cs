using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components.Nodes;
using Adder.Components;

namespace Adder.Factories
{
    public class NodeFactory
    {
        private static NodeFactory instance = null;
        private Dictionary<string, Func<Node>> _prototypes = new Dictionary<string, Func<Node>>()
        {
            { "AND", () => { return new And(); }},
            { "NOT", () => { return new Not(); }},
            { "NAND", () => { return new Nand(); }},
            { "NOR", () => { return new Nor(); }},
            { "OR", () => { return new Or(); }},
            { "XOR", () => { return new Xor(); }},
        };

        public static NodeFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new NodeFactory();
            }
            return instance;
        }

        private NodeFactory()
        {
            Initialize();
        }

        private void Initialize()
        {
            //_prototypes["AND"] = () {  return new And()};
            //_prototypes["NOT"] = new Not();
            //_prototypes["NAND"] = new Nand();
            //_prototypes["NOR"] = new Nor();
            //_prototypes["OR"] = new Or();
            //_prototypes["XOR"] = new Xor();
        }

        //public void RegisterNode(string name, Node node)
        //{
        //    _prototypes[name] = node;
        //}

        public Node Create(String type)
        {
            return _prototypes[type]();

            //prototype = prototype.Clone();

            //return prototype;
        }
    }
}
