using PostTestDrawBoard.Items.Item;
using PostTestDrawBoard.Items.Packs;

namespace PostTestDrawBoard
{
    public class AItem : Item
    {
        public AItem()
            :base(new decimal(1.25), new ItemPack(3, new decimal(3.00)))
        {
        }
    }
}
