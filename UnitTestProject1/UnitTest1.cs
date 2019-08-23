using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1 : AppSession
    {
        [TestMethod]
        public void Test00_LoginFailed()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            session.FindElementByName("Login").Click();

            Thread.Sleep(TimeSpan.FromMilliseconds(100));

            var dialog = session.FindElementByName("Login Failed");
            Assert.IsNotNull(dialog);

            session.FindElementByName("OK").Click();
        }

        [TestMethod]
        public void Test01_LoginSuccess()
        {
            Login();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
