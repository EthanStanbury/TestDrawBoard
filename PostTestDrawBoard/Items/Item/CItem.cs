using PostTestDrawBoard.Items.Item;
using PostTestDrawBoard.Items.Packs;

namespace PostTestDrawBoard
{
    public class CItem : Item
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        public CItem()
            :base(new decimal(1.00), new ItemPack(6, new decimal(5.00)))
        {
        }
    }
}
