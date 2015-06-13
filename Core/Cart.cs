﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core
{
    public class Cart
    {
        private IList<CartItem> items = new List<CartItem>();

        public void Add(Product product, int quantity)
        {
            var item = items.SingleOrDefault(x => x.Product == product);


            if (quantity < 0)
            {
                throw new Exception();
            }
            if (item == null)
            {
                items.Add(new CartItem(product, quantity));
            }
            else
            {
                item.ChangeQuantityBy(quantity);
            }
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return items.Select(y => y.Product);
            }
        }

        public decimal Price
        {
            get
            {
                return items.Sum(x => x.Price);
            }
        }
    }
}
