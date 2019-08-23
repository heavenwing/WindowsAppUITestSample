using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1 : AppSession
    {
        [TestMethod]
        public void Test00_HasTreeItemsOnInit()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var lstItems = session.FindElementByAccessibilityId("lstItems");

            Assert.AreEqual(3, lstItems.FindElementsByTagName("ListItem").Count);
        }

        [TestMethod]
        public void Test01_AddSuccess()
        {
            var lstItems = session.FindElementByAccessibilityId("lstItems");

            var countOld = lstItems.FindElementsByTagName("ListItem").Count;

            session.FindElementByAccessibilityId("txtItem").SendKeys("zyg");
            session.FindElementByAccessibilityId("btnAdd").Click();

            var countNew= lstItems.FindElementsByTagName("ListItem").Count;

            Assert.IsTrue(countNew > countOld);
        }

        [TestMethod]
        public void Test02_AddFailed()
        {
            var lstItems = session.FindElementByAccessibilityId("lstItems");

            var countOld = lstItems.FindElementsByTagName("ListItem").Count;

            var txtItem = session.FindElementByAccessibilityId("txtItem");
            txtItem.Clear();
            txtItem.SendKeys("123");
            session.FindElementByAccessibilityId("btnAdd").Click();//should cannot add number

            var countNew = lstItems.FindElementsByTagName("ListItem").Count;

            Assert.IsTrue(countNew == countOld);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
            Login();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
