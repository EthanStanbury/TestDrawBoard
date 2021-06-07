using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PostTestDrawBoard;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoardTest
{
    [TestClass]
    public class DItemTests
    {
        private Mock<DItem> DItem;

        [TestInitialize]
        public void Setup()
        {
            DItem = new Mock<DItem>();
            DItem.CallBase = true;
        }


        [TestMethod]
        public void DItemKnownPathOnlyPack()
        {
            var dItemObj = DItem.Object;
            DItem.Setup(di => di.DeterminePrice());
            
            for (int i = 0; i < 6; i++)
            {
                dItemObj.AddItem();
            }

            Assert.IsTrue(dItemObj.DeterminePrice() == new decimal(4.50));
            DItem.Verify(di => di.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void DItemKnownPathOnly()
        {
            var dItemObj = DItem.Object;
            DItem.Setup(di => di.DeterminePrice());

            for (int i = 0; i < 4; i++)
            {
                dItemObj.AddItem();
            }

            Assert.IsTrue(dItemObj.DeterminePrice() == new decimal(3.00));
            DItem.Verify(di => di.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void DItemKnownPathOnlyNothing()
        {
            var dItemObj = DItem.Object;
            DItem.Setup(di => di.DeterminePrice());
            Assert.IsTrue(dItemObj.DeterminePrice() == new decimal(0));
            DItem.Verify(di => di.DeterminePrice(), Times.Once());
        }
    }
}
