using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components.Nodes
{
    public class Or : Node
    {
        public override void Handle()
        {
            Output = false;

            InputList.ForEach((bool input) =>
            {
                if (input)
                {
                    Output = true;
                }
            });


            base.Handle();
        }

        public override Node Clone()
        {
            return this.MemberwiseClone() as Node;
        }
    }
}
