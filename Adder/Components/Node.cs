﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adder.Visitors;

namespace Adder.Components
{
    public abstract class Node : Component //Leaf
    {

        public Dictionary<string, bool> DefaultInputs { get; set; }
        public List<bool> InputList { get; set; }
        public List<Edge> OutputList { get; set; }

        public bool Output { get; set; }
        public int NrOfInputs { get; set; }

        public string OutputName { get; set; }

        public Node()
        {
            OutputList = new List<Edge>();
            InputList = new List<bool>();
            DefaultInputs = new Dictionary<string, bool>();
            OutputName = null;
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
                      //  edge.Out.Run(visitor);
                    }
                });
            }
        }

        //This runs before the specific node handle
        public virtual void Handle()
        {
            SetDefaultInputs();
        }

        public void AddOutput(Node output)
        {
            this.OutputList.Add(new Edge(this, output));
            output.NrOfInputs++;
        }

        public void AddInput(Node input)
        {
            input.OutputList.Add(new Edge(input, this));
            this.NrOfInputs++;
        }

        //Add input not coming from nodes
        public void AddDefaultInputs(string name,bool input)
        {
            this.DefaultInputs.Add(name, input);
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
                InputList.AddRange(DefaultInputs.Values);
            }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
