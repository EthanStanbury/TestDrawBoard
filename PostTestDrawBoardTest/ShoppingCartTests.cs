using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostTestDrawBoard;
using PostTestDrawBoard.Items.Interfaces;
using PostTestDrawBoard.Items.Item;
using PostTestDrawBoard.ShoppingCart;

namespace PostTestDrawBoardTest
{
    [TestClass]
    public class ShoppingCartTests
    {
        private ShoppingCart ShoppingCartMock;
        private Mock<AItem> AItemMock;
        private Mock<BItem> BItemMock;
        private Mock<CItem> CItemMock;
        private Mock<DItem> DItemMock;

        [TestInitialize]
        public void Setup()
        {
            AItemMock = new Mock<AItem>();
            BItemMock = new Mock<BItem>();
            CItemMock = new Mock<CItem>();
            DItemMock = new Mock<DItem>();
            ShoppingCartMock = new ShoppingCart(AItemMock.Object, BItemMock.Object, CItemMock.Object, DItemMock.Object);
        }

        [TestMethod]
        public void AItemKnownPathOnly2Pack()
        {
            AItemMock.Setup(aim => aim.DeterminePrice()).Returns(new decimal(6.00));
            AItemMock.Setup(aim => aim.AddItem());
            ShoppingCartMock = new ShoppingCart(AItemMock.Object, BItemMock.Object, CItemMock.Object, DItemMock.Object);
            var total = ShoppingCartMock.GetTotal("AAAAAA");
            Assert.IsTrue(total == new decimal(6.00));
        }
        [TestMethod]
        public void CItemsKnownPathOnly2Pack()
        {
            CItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(6.00));
            CItemMock.Setup(cim => cim.AddItem());
            ShoppingCartMock = new ShoppingCart(AItemMock.Object, BItemMock.Object, CItemMock.Object, DItemMock.Object);
            var total = ShoppingCartMock.GetTotal("CCCCCCC");
            Assert.IsTrue(total == new decimal(6.00));
        }
        [TestMethod]
        public void OneItemKnownPathOnly()
        {
            AItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(1.25));
            AItemMock.Setup(cim => cim.AddItem());
            BItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(4.25));
            BItemMock.Setup(cim => cim.AddItem());
            CItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(1.00));
            CItemMock.Setup(cim => cim.AddItem());
            DItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(0.75));
            DItemMock.Setup(cim => cim.AddItem());
            ShoppingCartMock = new ShoppingCart(AItemMock.Object, BItemMock.Object, CItemMock.Object, DItemMock.Object);
            var total = ShoppingCartMock.GetTotal("ABCD");
            Assert.IsTrue(total == new decimal(7.25));
        }

        [TestMethod]
        public void RandomItemsKnownPathOnly1Pack()
        {
            AItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(3.00));
            AItemMock.Setup(cim => cim.AddItem());
            BItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(8.50));
            BItemMock.Setup(cim => cim.AddItem());
            CItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(1.00));
            CItemMock.Setup(cim => cim.AddItem());
            DItemMock.Setup(cim => cim.DeterminePrice()).Returns(new decimal(0.75));
            DItemMock.Setup(cim => cim.AddItem());
            ShoppingCartMock = new ShoppingCart(AItemMock.Object, BItemMock.Object, CItemMock.Object, DItemMock.Object);
            var total = ShoppingCartMock.GetTotal("ABCD");
            Assert.IsTrue(total == new decimal(13.25));
        }

        [TestMethod]
        public void WrongItems()
        {
            try
            {
                ShoppingCartMock.GetTotal("z");
            }
            catch (ShoppingItemException e)
            {
                Assert.IsTrue(e.Message.Equals("Item Z not found in system. This developer should probably handle this error is a service layer somewhere", StringComparison.InvariantCulture));
                Assert.IsInstanceOfType(e,typeof(ShoppingItemException));
            }
        }
    }
}
