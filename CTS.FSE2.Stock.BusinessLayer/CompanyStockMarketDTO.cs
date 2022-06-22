using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Stock.BusinessLayer
{

    public class CompanyStockMarketDTO
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public double AvgPrice { get; set; }
        public List<CompanyStockMarketPriceDTO> stockMarketPrices { get; set; }
    }
    public class CompanyStockMarketPriceDTO
    {
        public double StockPrice { get; set; }
        public string StockDate { get; set; }
        public string StockTime { get; set; }

    }
}
