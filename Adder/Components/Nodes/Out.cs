﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components.Nodes
{
    public class Out : Node
    {
        public override Node Clone()
        {
            return this.MemberwiseClone() as Node;
        }
    }
}
