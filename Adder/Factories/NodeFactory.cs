using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Components.Nodes;
using Adder.Components;

namespace Adder.Factories
{
    class NodeFactory
    {
		private Dictionary<string, Node> _prototypes = new Dictionary<string, Node>();

        public NodeFactory()
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
            _prototypes["PROBE"] = new Out();
            _prototypes["INPUT"] = new In();
            _prototypes["XOR"] = new Xor();
        }

        public void RegisterNode(string name, Node node)
        {
            _prototypes[name] = node;
        }

        public Node Create(String type)
        {
            Node prototype = _prototypes[type];

            //return prototype.Clone();
            return null;
        }
    }
}
