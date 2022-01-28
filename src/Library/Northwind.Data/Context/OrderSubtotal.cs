using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Data.Context
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
