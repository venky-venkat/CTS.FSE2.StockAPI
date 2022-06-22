using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Stock.DataLayer
{
   public interface IStockRepository
    {
        public void Addstock(StockBE stockBE);
        public StockMarketEntity get(string code, string startdate, string enddate);
    }
}
