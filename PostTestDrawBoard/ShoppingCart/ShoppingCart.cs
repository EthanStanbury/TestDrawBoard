using System;
using Microsoft.Extensions.DependencyInjection;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoard.ShoppingCart
{
    /// <summary>
    /// The shopping cart class, this is for management of items that are being purchased. 
    /// </summary>
    public class ShoppingCart : IShoppingCart
    {
        private readonly ServiceProvider serviceProvider;


        /// <summary>
        /// Only used for test methods. 
        /// </summary>
        /// <param name="aItem"></param>
        /// <param name="bItem"></param>
        /// <param name="cItem"></param>
        /// <param name="dItem"></param>
        public ShoppingCart(AItem aItem = null, BItem bItem = null, CItem cItem = null, DItem dItem = null)
        {
            serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton(aItem ?? new AItem())
                .AddSingleton(bItem ?? new BItem())
                .AddSingleton(cItem ?? new CItem())
                .AddSingleton(dItem ?? new DItem())
                .BuildServiceProvider();
        }

        public ShoppingCart()
        {
            serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton(new AItem())
                .AddSingleton(new BItem())
                .AddSingleton(new CItem())
                .AddSingleton(new DItem())
                .BuildServiceProvider();
        }

        /// <summary>
        /// Given a shopping list calculate the final cost. I don't love the switch, but I think with a UI it would be easier to implement a nice solution
        /// </summary>
        /// <param name="shoppingList">The string list to calculate the final total</param>
        /// <returns>The final price</returns>
        public decimal GetTotal(string shoppingList)
        {
            foreach (var item in shoppingList.ToUpperInvariant())
            {
                switch (item)
                {
                    //A
                    case 'A':
                        serviceProvider.GetService<AItem>().AddItem();
                        break;
                    //B
                    case 'B':
                        serviceProvider.GetService<BItem>().AddItem();
                        break;
                    //C
                    case 'C':
                        serviceProvider.GetService<CItem>().AddItem();
                        break;
                    //D
                    case 'D':
                        serviceProvider.GetService<DItem>().AddItem();
                        break;
                    default:
                        // maybe skip and return message in console 
                        throw new ShoppingItemException(string.Format("Item {0} not found in system. This developer should probably handle this error is a service layer somewhere", item));
                }
            }

            return serviceProvider.GetService<AItem>().DeterminePrice() + serviceProvider.GetService<BItem>().DeterminePrice() + serviceProvider.GetService<CItem>().DeterminePrice() + serviceProvider.GetService<DItem>().DeterminePrice();
        }
    }
}
