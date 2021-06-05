using System;
using System.Collections.Generic;
using System.Text;

namespace PostTestDrawBoard.Items.Interfaces
{
    public interface IPack
    {
        public decimal DeterminePackPrice(int fruitAmount, decimal fruitPrice);
    }
}
