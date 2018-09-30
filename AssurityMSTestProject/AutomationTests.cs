using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductConsoleApp;

namespace AssurityMSTestProject
{
    [TestClass]
    public class AutomationTests
    {
        /// <summary>
        /// I strongly advise against combining three acceptance criteria in to an automated test as per the assignment criteria. 
        /// For this reason I have created a combined test as well as three separate tests. One for each acceptance criteria.
        /// 
        /// Automated test that verifies three acceptance criteria:
        /// Name = "Carbon credits"
        /// CanRelist = true
        /// The Promotions element with Name = "Gallery" has a Description that contains the text "2x large image"
        /// </summary>
        [TestMethod]
        public void VerifyThreeCriteria()
        {
            //Create a variable that contains the Category name
            var CategoryName = Program.GetCategory().GetAwaiter().GetResult();
            //Create a list of Promotion JSON objects
            var promotions = Program.GetPromotionList().GetAwaiter().GetResult();
            //Get the boolean value of Category CanRelist item
            bool CategoryCanRelist = Program.GetCanRelistStatus().GetAwaiter().GetResult();

            //Verify the Name of the Category JSON object is "Carbon credits" else fail and report error
            Assert.IsTrue(CategoryName.Equals("Carbon credits"), "Product name is not equal to \"Carbon credits\"");
            //Verify the boolean "true status" of the Category CanRelist status, else fail and report error
            Assert.IsTrue(CategoryCanRelist, "CanRelist status is \"false\" and not \"true\" as expected");
            //Verify the string content "2x large image" in the Promotion item with Name "Gallery"
            foreach (var item in promotions)
            {
                if (item.Name.Equals("Gallery"))
                {
                    Assert.IsTrue(item.Description.ToString().Contains("2x larger image"), 
                        "Gallery description varification is not equal to \"2x large image\"");
                }
            }
        }
        //Verify the Name of the Category JSON object
        [TestMethod]
        public void VerifyNameCarbonCredits()
        {
            var CategoryName = Program.GetCategory().GetAwaiter().GetResult();
            Assert.IsTrue(CategoryName.Equals("Carbon credits"), "Product name is not equal to \"Carbon credits\"");
        }
        //Verify the boolean "true status" of the Category CanRelist status
        [TestMethod]
        public void VerifyCanRelistTrue()
        {
            bool CategoryCanRelist = Program.GetCanRelistStatus().GetAwaiter().GetResult();
            Assert.IsTrue(CategoryCanRelist, "CanRelist status is \"false\" and not \"true\" as expected");
        }
        //Verify the string content "2x large image" in the Promotion item with Name "Gallery"
        [TestMethod]
        public void VerifyPromotionText()
        {
            var promotions = Program.GetPromotionList().GetAwaiter().GetResult();
            foreach (var item in promotions)
            {
                if(item.Name.Equals("Gallery"))
                {
                    Assert.IsTrue(item.Description.ToString().Contains("2x larger image"),
                        "Gallery description varification is not equal to \"2x large image\"");
                }
            }
        }
        
    }
}
