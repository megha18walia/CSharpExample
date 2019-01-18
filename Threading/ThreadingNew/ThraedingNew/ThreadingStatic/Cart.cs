using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingStatic
{
   public  class Cart
    {
        public Cart()
        {
            GroceryItems = new GroceryItem[10];

            GroceryItems[0] = new GroceryItem("Milk", 1.00f);
            GroceryItems[1] = new GroceryItem("Bread", 1.00f);
            GroceryItems[2] = new GroceryItem("Cheese", 1.00f);
            GroceryItems[3] = new GroceryItem("Eggs", 1.00f);
            GroceryItems[4] = new GroceryItem("Soda", 1.00f);
            GroceryItems[5] = new GroceryItem("Candy", 1.00f);
            GroceryItems[6] = new GroceryItem("Lettuc", 1.00f);
            GroceryItems[7] = new GroceryItem("Tomato", 1.00f);
            GroceryItems[8] = new GroceryItem("Fish", 1.00f);
            GroceryItems[9] = new GroceryItem("Cereal", 1.00f);
        }

        public GroceryItem[] GroceryItems;
    }
}
