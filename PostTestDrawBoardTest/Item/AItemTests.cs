using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using PostTestDrawBoard;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoardTest
{
    [TestClass]
    public class AItemTests
    {
        private Mock<AItem> AItem;

        [TestInitialize]
        public void Setup()
        {
            AItem = new Mock<AItem>();
            AItem.CallBase = true;
        }

        [TestMethod]
        public void AItemKnownPathOnlyPack()
        {
            var aItemObj = AItem.Object;
            AItem.Setup(ai => ai.DeterminePrice());
            
            for (int i = 0; i < 6; i++)
            {
                aItemObj.AddItem();
            }

            Assert.IsTrue(aItemObj.DeterminePrice() == new decimal(6.00));
            AItem.Verify(ai => ai.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void AItemKnownPathOnly()
        {
            var aItemObj = AItem.Object;
            AItem.Setup(ai => ai.DeterminePrice());

            for (int i = 0; i < 4; i++)
            {
                aItemObj.AddItem();
            }

            Assert.IsTrue(aItemObj.DeterminePrice() == new decimal(4.25));
            AItem.Verify(ai => ai.DeterminePrice(), Times.Once());
        }
        [TestMethod]
        public void AItemKnownPathOnlyNothing()
        {
            var aItemObj = AItem.Object;
            AItem.Setup(ai => ai.DeterminePrice());
            Assert.IsTrue(aItemObj.DeterminePrice() == new decimal(0));
            AItem.Verify(ai => ai.DeterminePrice(), Times.Once());
        }
    }
}
