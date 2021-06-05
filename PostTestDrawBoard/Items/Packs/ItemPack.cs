using System;
using System.Collections.Generic;
using System.Text;
using PostTestDrawBoard.Items.Interfaces;

namespace PostTestDrawBoard.Items.Packs
{
    public class ItemPack : IPack
    {
        private int PackComboLimit;
        private decimal PackComboPrice;

        public ItemPack(int packComboLimit, decimal packComboPrice)
        {
            PackComboLimit = packComboLimit;
            PackComboPrice = packComboPrice;
        }

        public decimal DeterminePackPrice(int fruitAmount, decimal fruitPrice)
        {
            int packAmount = fruitAmount / PackComboLimit;
            int packRemainder = fruitAmount % PackComboLimit;
            return (packAmount * PackComboPrice) + (packRemainder * fruitPrice);
        }
    }
}
