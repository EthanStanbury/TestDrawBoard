using System;
using System.Collections.Generic;
using System.Text;
using PostTestDrawBoard.Items.Interfaces;

namespace PostTestDrawBoard.Items.Packs
{
    /// <summary>
    /// Base class for the ItemPack can be extended to provide future use if business logic changes.
    /// </summary>
    public class ItemPack : IPack
    {
        private int PackComboLimit;
        private decimal PackComboPrice;

        public ItemPack(int packComboLimit, decimal packComboPrice)
        {
            PackComboLimit = packComboLimit;
            PackComboPrice = packComboPrice;
        }
        /// <summary>
        /// Find how many times they get a pack deal, add the remainder
        /// </summary>
        /// <param name="fruitAmount">Amount of fruit purchased.</param>
        /// <param name="fruitPrice">The price of the fruit.</param>
        /// <returns>Final Total price</returns>
        public virtual decimal DeterminePackPrice(int fruitAmount, decimal fruitPrice)
        {
            int packAmount = fruitAmount / PackComboLimit;
            int packRemainder = fruitAmount % PackComboLimit;
            return (packAmount * PackComboPrice) + (packRemainder * fruitPrice);
        }
    }
}
