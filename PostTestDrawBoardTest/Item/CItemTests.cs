using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PostTestDrawBoard;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoardTest
{
    [TestClass]
    public class CItemTests
    {
        private Mock<CItem> CItem;

        [TestInitialize]
        public void Setup()
        {
            CItem = new Mock<CItem>();
            CItem.CallBase = true; 
        }


        [TestMethod]
        public void CItemKnownPathOnlyPack()
        {
            var cItemObj = CItem.Object;
            CItem.Setup(ci => ci.DeterminePrice());
            
            for (int i = 0; i < 6; i++)
            {
                cItemObj.AddItem();
            }
            
            Assert.IsTrue(cItemObj.DeterminePrice() == new decimal(5.00));
            CItem.Verify(ci => ci.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void CItemKnownPathOnly()
        {
            var cItemObj = CItem.Object;
            CItem.Setup(ci => ci.DeterminePrice());

            for (int i = 0; i < 4; i++)
            {
                cItemObj.AddItem();
            }

            Assert.IsTrue(cItemObj.DeterminePrice() == new decimal(4.00));
            CItem.Verify(ci => ci.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void CItemKnownPathOnlyNothing()
        {
            var cItemObj = CItem.Object;
            CItem.Setup(ci => ci.DeterminePrice());
            Assert.IsTrue(cItemObj.DeterminePrice() == new decimal(0));
            CItem.Verify(ci => ci.DeterminePrice(), Times.Once());
        }
    }
}
