using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Florian_TOCCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Florian_TOCCO.Tests
{
    [TestClass()]
    public class InputManagerTests
    {
        [TestMethod()]
        public void checkIntValidityTest1()
        {
            Assert.IsFalse(InputManager.checkIntValidity(0));
        }

        [TestMethod()]
        public void checkIntValidityTest2()
        {
            Assert.IsTrue(InputManager.checkIntValidity(8));
        }

        [TestMethod()]
        public void checkIntValidityTest3()
        {
            Assert.IsFalse(InputManager.checkIntValidity(8, maxValue: 5));
        }
    }
}