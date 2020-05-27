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
        private Dictionary<string, Node> _prototypes = new Dictionary<string, Node>();

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
            _prototypes["AND"] = new And();
            _prototypes["NOT"] = new Not();
            _prototypes["NAND"] = new Nand();
            _prototypes["NOR"] = new Nor();
            _prototypes["OR"] = new Or();
            _prototypes["XOR"] = new Xor();

            _prototypes["INPUT"] = new In();
            _prototypes["OUTPUT"] = new Out();
        }

        public void RegisterNode(string name, Node node)
        {
            _prototypes[name] = node;
        }

        public Node Create(String type)
        {
            Node prototype = _prototypes[type];

            return prototype.Clone();
        }
    }
}
