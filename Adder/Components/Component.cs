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
        public List<bool> InputList { get; set; }
        public List<Edge> OutputList { get; set; }

        public string Name { get; set; }
        public bool Output { get; set; }

        public TimeSpan TimeSpan { get; set; }
        //protected IVisitor _visitor;

        public virtual void Run(IVisitor visitor)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            

            this.Accept(visitor);


            timer.Stop();
            this.TimeSpan = timer.Elapsed;
            //this.PrintTime();
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
