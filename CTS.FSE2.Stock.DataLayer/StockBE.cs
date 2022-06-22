using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTS.FSE2.Stock.DataLayer
{
   public class StockBE
    {
        public ObjectId id { get; set; }
        public string CompanyCode { get; set; }
        [Required]
        
        public double StockPrice { get; set; }
        public DateTime StockDate { get; set; }

    }
}
