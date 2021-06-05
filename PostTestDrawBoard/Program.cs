using PostTestDrawBoard.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace PostTestDrawBoard
{
    class Program
    {
        private static ShoppingCart ShoppingCart = new ShoppingCart();
        static void Main(string[] args)
        {

            var inputString = Console.ReadLine();
            


            

            
            Console.WriteLine(ShoppingCart.GetTotal(inputString));


            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            ////do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
            //bar.DoSomeRealWork();

            //
            //logger.LogDebug("All done!");


            // look at doing  dependacy injection for classes
            // Interface everything 
            // Have a subclass for the varity packs
            // Have an enum for the variety code??? Something to make it easy to convert it to an object 
            // Have a class for each product
            // Have a seperate method for determaining price of each item that they inherit from 
            // Have a count for each object per scanned thing in string
            // Use modular to figure remainder for price
            // DO YOUR TESTS <-----  interface and dependacy injections

        }
    }
}
