using System;
using Microsoft.Extensions.DependencyInjection;
using PostTestDrawBoard.Items.Item;

namespace PostTestDrawBoard
{
    class ShoppingCart
    {
        private readonly ServiceProvider serviceProvider;

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
                        throw new Exception("Do something with me");
                }
            }

            return serviceProvider.GetService<AItem>().DeterminePrice() + serviceProvider.GetService<BItem>().DeterminePrice() + serviceProvider.GetService<CItem>().DeterminePrice() + serviceProvider.GetService<DItem>().DeterminePrice();
        }
    }
}
