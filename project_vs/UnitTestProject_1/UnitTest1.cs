using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project_N;
using System.Data;
using System.Windows.Forms;
namespace UnitTestProject_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            data.buf = "add";
            var form = new ClientAE();

            form.panel_add = new Panel();
            form.panel_edit = new Panel();

            form.Loaded();

            Assert.IsTrue(form.panel_add.Visible);
        }

    }
}
