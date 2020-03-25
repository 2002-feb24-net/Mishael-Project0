using PZero.dtb;
using PZero.dtb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZero.app
{
    class OrderCart : IOrderList
    {
        public int CustID { get; set; }
        public List<OrderData> Cart { get; set; }

        public OrderCart(int x)
        {
            CustID = x;
            Cart = new List<OrderData>();
        }

        public decimal GetCurrentTotal()
        {
            decimal x = 0.0M;
            foreach (var item in Cart)
            {
                x += item.Price * item.Quantity;
            }
            return x;
        }
    }
}
