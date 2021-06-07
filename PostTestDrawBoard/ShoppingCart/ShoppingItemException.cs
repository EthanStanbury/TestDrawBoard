using System;

namespace PostTestDrawBoard.ShoppingCart
{
    public class ShoppingItemException : Exception
    {
        public ShoppingItemException()
        {
        }

        public ShoppingItemException(string message)
            : base(message)
        {
        }

        public ShoppingItemException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
