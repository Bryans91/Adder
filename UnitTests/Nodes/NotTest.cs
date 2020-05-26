﻿using Adder.Components;
using Adder.Components.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Nodes
{
    [TestClass]
    public class NotTest
    {
        [TestMethod]
        public void TestHandle()
        {
            Node node = new Not();
            node.AddDefaultInputs(false);
            node.SetDefaultInputs();

            node.Handle();

            Assert.IsTrue(node.Output);
        }

        [TestMethod]
        public void TestHandleNegative()
        {
            Node node = new Not();
            node.AddDefaultInputs(true);
     
            node.SetDefaultInputs();

            node.Handle();

            Assert.IsFalse(node.Output);
        }

    }
}
