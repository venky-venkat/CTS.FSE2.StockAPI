using CTS.FSE2.Stock.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTS.FSE2.Stock.BusinessLayer
{
   public class StockBL: IStockBL
    {
        public readonly IStockRepository _stockrepository;
        public StockBL(IStockRepository stockRepository)
        {
            _stockrepository = stockRepository;
        }
        public void Addstock(StockDTO stockBE)
        {
             
            _stockrepository.Addstock(new StockBE { 
            CompanyCode = stockBE.CompanyCode,
            StockPrice = stockBE.StockPrice,
            StockDate = DateTime.Now
            });
        }

        public CompanyStockMarketDTO get(string code, string startdate, string enddate)
        {
            CompanyStockMarketDTO companies = new CompanyStockMarketDTO();
            CompanyStockMarketPriceDTO stockMarketDTO = null;
            List<CompanyStockMarketPriceDTO> ListstockMarketDTO = new List<CompanyStockMarketPriceDTO>();
            var result = _stockrepository.get(code,startdate,enddate);
            if (result != null)
            {
                if (result.stockMarketPrices.Count > 0)
                {
                    foreach (var stock in result.stockMarketPrices)
                    {
                        if (stock.StockDate.Date >= Convert.ToDateTime(startdate).Date
                            && stock.StockDate.Date <= Convert.ToDateTime(enddate).Date)
                        {
                            stockMarketDTO = new CompanyStockMarketPriceDTO
                            {
                                StockDate = stock.StockDate.ToString("d"),
                                StockTime = stock.StockDate.ToString("hh:mm tt"),
                                StockPrice = stock.StockPrice
                            };
                            ListstockMarketDTO.Add(stockMarketDTO);
                        }
                    }
                }
                else
                {
                    ListstockMarketDTO.Clear();
                }
                
                

                return new CompanyStockMarketDTO
                {
                    //CompanyCEO = result.CompanyCEO,
                    CompanyCode = result.CompanyCode,
                    CompanyName = result.CompanyName,
                    //CompanyTurnOver = result.CompanyTurnOver,
                    //CompanyWebsite = result.CompanyWebsite,
                    //StockExchange = result.StockExchange,
                    stockMarketPrices = ListstockMarketDTO,
                    MinPrice = ListstockMarketDTO.Count>0? ListstockMarketDTO.Min(x=>x.StockPrice) : 0,
                    MaxPrice = ListstockMarketDTO.Count > 0 ? ListstockMarketDTO.Max(x => x.StockPrice) : 0,
                    AvgPrice = ListstockMarketDTO.Count > 0 ? ListstockMarketDTO.Average(x => x.StockPrice) : 0,
                };
            }
             return null;
        }
           
    }
}
