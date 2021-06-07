using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PostTestDrawBoard;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoardTest
{
    [TestClass]
    public class BItemTests
    {
        private Mock<BItem> BItem;

        [TestInitialize]
        public void Setup()
        {
            BItem = new Mock<BItem>();
            BItem.CallBase = true;
        }

        [TestMethod]
        public void BItemKnownPathOnly()
        {
            var bItemObj = BItem.Object;
            BItem.Setup(bi => bi.DeterminePrice());

            for (int i = 0; i < 10; i++)
            {
                bItemObj.AddItem();
            }

            Assert.IsTrue(bItemObj.DeterminePrice() == new decimal(42.50));
            BItem.Verify(bi => bi.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void BItemKnownPathOnlyNothing()
        {
            var bItemObj = BItem.Object;
            BItem.Setup(bi => bi.DeterminePrice());
            Assert.IsTrue(bItemObj.DeterminePrice() == new decimal(0));
            BItem.Verify(bi => bi.DeterminePrice(), Times.Once());
        }
    }
}
