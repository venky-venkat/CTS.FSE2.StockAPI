using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Stock.BusinessLayer
{
   public interface IStockBL
    {
        public void Addstock(StockDTO stockBE);
        public CompanyStockMarketDTO get(string code, string startdate, string enddate);
    }

}
