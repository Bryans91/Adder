using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Factories;
using Adder.Components;

namespace Adder.Builders
{
    class Builder : IBuilder
    {
        private NodeFactory nodeFactory;

        public Builder()
        {
            nodeFactory = NodeFactory.GetInstance();
        }
    }
}
