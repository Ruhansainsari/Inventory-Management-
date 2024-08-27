using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class StockAdd
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }

        public StockAdd(string stockName, string stockCode, int stockQuantity)
        {
            Name = stockName;
            Code = stockCode;
            Quantity = stockQuantity;
        }
    }
}
