using System;
using System.Collections.Generic;
using System.Text;
using PostTestDrawBoard.Items.Interfaces;
using PostTestDrawBoard.Items.Packs;

namespace PostTestDrawBoard.Items.Item
{
    public class  Item : IItem
    {
        public int Count = 0;
        public IPack? Pack;
        public decimal Price;
        
        public virtual decimal DeterminePrice()
        {
            if (Pack != null && Count > 0)
            {
                return Pack.DeterminePackPrice(Count, Price);
            }

            return Count * Price;
        }

        public Item()
        {
        }

        public Item(decimal price, ItemPack pack = null)
        {
            Price = price;
            Pack = pack;
        }
        public void AddItem()
        {
            Count += 1;
        }
    }
}
