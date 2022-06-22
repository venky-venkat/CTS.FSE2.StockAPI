using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTS.FSE2.Stock.BusinessLayer
{
   public class StockDTO
    {
            public string CompanyCode { get; set; }
        [Required]
      
            public double StockPrice { get; set; }
            public DateTime StockDate { get; set; }
    }
}
