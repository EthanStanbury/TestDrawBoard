using System;
using PostTestDrawBoard.ShoppingCart;

namespace PostTestDrawBoard
{
    class Program
    {
        private static ShoppingCart.ShoppingCart ShoppingCart = new ShoppingCart.ShoppingCart();
        static void Main(string[] args)
        {

            Console.WriteLine("Please input the shopping list.");
            string inputString = string.Empty;
            while (inputString != "~")
            {
                try
                {

                inputString = Console.ReadLine();
                Console.WriteLine(ShoppingCart.GetTotal(inputString));
                }
                catch (ShoppingItemException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
