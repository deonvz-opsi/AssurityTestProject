using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;
using ProductConsoleApp;

namespace AssurityMSTestProject
{
    [TestClass]
    public class AutomationTests
    {
        
        [TestMethod]
        public void VerifyNameCarbonCredits()
        {
            var ProductName = Program.GetProductName().GetAwaiter().GetResult();
            Assert.IsTrue(ProductName.Equals("Carbon credits"), "Product name is not equal to \"Carbon credits\"");
        }

        [TestMethod]
        public void VerifyCanRelistTrue()
        {
            bool ProductNameRelist = Program.GetCanRelistStatus().GetAwaiter().GetResult();
            Assert.IsTrue(ProductNameRelist);
        }

        [TestMethod]
        public void VerifyPromotionText()
        {
            var items = Program.GetPromotionList().GetAwaiter().GetResult();
            foreach (var item in items)
            {
                if(item.Name.Equals("Gallery"))
                {
                    Assert.IsTrue(item.Description.ToString().Contains("2x larger image"), "Gallery description varification has failed");
                }
            }
        }
    }
}
