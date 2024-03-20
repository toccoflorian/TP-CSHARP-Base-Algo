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
    public class ResponseRequestTests
    {
        [TestMethod()]
        public void CheckStringValidityTest1()
        {
            Assert.IsFalse(InputManager.CheckStringValidity("f"));
        }

        [TestMethod()]
        public void CheckStringValidityTest2()
        {
            Assert.IsTrue(InputManager.CheckStringValidity("AMG"));
        }

        [TestMethod()]
        public void CheckStringValidityTest3()
        {
            Assert.IsTrue(InputManager.CheckStringValidity("1234", maxLength: 6, minLength: 4));
        }

        [TestMethod()]
        public void CheckStringValidityTest4()
        {
            Assert.IsTrue(InputManager.CheckStringValidity("123456", maxLength: 6, minLength: 4));
        }

        [TestMethod()]
        public void CheckStringValidityTest5()
        {
            Assert.IsFalse(InputManager.CheckStringValidity("123", maxLength: 6, minLength: 4));
        }

        [TestMethod()]
        public void CheckStringValidityTest6()
        {
            Assert.IsFalse(InputManager.CheckStringValidity("1234567", maxLength: 6, minLength: 4));
        }

        [TestMethod()]
        public void CheckMarqueValidityTest()
        {
            Assert.IsFalse(InputManager.CheckMarqueValidity("marque5"));
        }
    }
}