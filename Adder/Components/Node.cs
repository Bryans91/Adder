using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Visitors;

namespace Adder.Components
{
    public abstract class Node : Component //Leaf
    {

        public List<bool> DefaultInputs { get; set; }
        public List<bool> InputList { get; set; }
        public List<Edge> OutputList { get; set; }

        public bool Output { get; set; }
        public int NrOfInputs { get; set; }

        public Node()
        {
            OutputList = new List<Edge>();
            InputList = new List<bool>();
            DefaultInputs = new List<bool>();
        }

        public override void Run(IVisitor visitor)
        {
            
            Handle(); //Do node action

            base.Run(visitor);

            //pass Data on
            if (IsResolveable())
            {
                OutputList.ForEach((Edge edge) =>
                {
                    edge.Out.InputList.Add(Output);
                    if(edge.Out.IsResolveable())
                    {
                        edge.Out.Run(visitor);
                    }
                });
            }
        }

        //This runs before the specific node handle
        public virtual void Handle()
        {
            SetDefaultInputs();
        }

        public virtual void AddOutput(Node output)
        {
            this.OutputList.Add(new Edge(this, output));
            output.NrOfInputs++;
        }

        //Add input not coming from nodes
        public virtual void AddDefaultInputs(bool input)
        {
            this.DefaultInputs.Add(input);
            this.NrOfInputs++;
        }

        public virtual bool IsResolveable()
        {
            return InputList.Count >= NrOfInputs;
        }

        public void SetDefaultInputs()
        {
            if (InputList.Count == 0 && DefaultInputs.Count > 0)
            {
                InputList.AddRange(DefaultInputs);
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public abstract Node Clone();

    }
}
