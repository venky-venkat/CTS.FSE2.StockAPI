using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.FSE2.Stock.DataLayer
{
    public class StockRepository : IStockRepository
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _db;
        public StockRepository(IOptions<DBModel> dbmodel)
        {
            _mongoClient = new MongoClient(dbmodel.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(dbmodel.Value.Database);
        }
        public void Addstock(StockBE stockBE)
        {
            _db.GetCollection<StockBE>("stock").InsertOne(stockBE);
        }

        public StockMarketEntity get(string code, string startdate, string enddate)
        {
            var stockmarketlist = _db.GetCollection<CompanyBE>("company").Aggregate()
                .Lookup("stock", "CompanyCode", "CompanyCode", "stockMarketPrices")
                .As<StockMarketEntity>().ToList();
            var companystock = stockmarketlist.Find(x => x.CompanyCode == code);
            return companystock;
        }
    }
}
