using Adder.Visitors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adder.Components
{
    public abstract class Component
    {
        public List<bool> DefaultInputs { get; set; }
        public List<bool> InputList { get; set; }
        public List<Edge> OutputList { get; set; }
        public int NrOfInputs { get; set; }

        public string Name { get; set; }
        public bool Output { get; set; }

        public bool Printed { get; set; } = false;
        public TimeSpan TimeSpan { get; set; }
      

        public Component()
        {
            OutputList = new List<Edge>();
            InputList = new List<bool>();
            DefaultInputs = new List<bool>();
        }

        public virtual void Run(IVisitor visitor)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            SetDefaultInputs();
      

            this.Accept(visitor);


            timer.Stop();
            this.TimeSpan = timer.Elapsed;
            //this.PrintTime();
        }

        public virtual bool IsResolveable()
        {
            return InputList.Count >= NrOfInputs;
        }

        private void SetDefaultInputs()
        {
            if(InputList.Count == 0 && DefaultInputs.Count > 0)
            {
                InputList.AddRange(DefaultInputs);
            }
        }

        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void PrintTime()
        {
            Console.WriteLine("Time elapsed (microseconds): {0}", TimeSpan.Ticks / 1000);
        }
    }
}
