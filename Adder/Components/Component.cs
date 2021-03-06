﻿using Adder.Visitors;
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
        public string Name { get; set; }
   
        public bool Printed { get; set; } = false;
        public TimeSpan TimeSpan { get; set; }
      

        public virtual void Run(IVisitor visitor)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            this.Accept(visitor);

            timer.Stop();
            this.TimeSpan = timer.Elapsed;
        }


        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void PrintTime()
        {
            Console.WriteLine("{0} ran for: {1} (microseconds)",  this.Name, TimeSpan.Ticks / 1000);
        }
    }
}
