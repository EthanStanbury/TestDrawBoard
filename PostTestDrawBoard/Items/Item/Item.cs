using System;
using System.Collections.Generic;
using System.Text;
using PostTestDrawBoard.Items.Interfaces;
using PostTestDrawBoard.Items.Packs;

namespace PostTestDrawBoard.Items.Item
{
    /// <summary>
    /// The base class that all of the items currently use. This class needs to be pretty generic as it is meant to service everything.
    /// Current logic is each item that inherits from 'Item' will determine its own price and if it has a pack, as that is the responsibility of that item.
    /// If this gets too complicated look at separating out items into other classes that inherit from here.
    /// </summary>
    public class Item : IItem
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
        public virtual void AddItem()
        {
            Count += 1;
        }
    }
}
