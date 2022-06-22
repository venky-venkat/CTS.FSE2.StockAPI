using CTS.FSE2.Stock.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS.FSE2.StockAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/market/stock/")]
    public class StockController : ControllerBase
    {
        public readonly IStockBL _stockBL;
        public StockController(IStockBL stockBL)
        {
            _stockBL = stockBL;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Addstock(StockDTO stockDTO)
        {
            if (ModelState.IsValid)
            {
                _stockBL.Addstock(stockDTO);
                return Ok(stockDTO);
            }
            return BadRequest();
            
        }

        [HttpGet]
        [Route("get")]
        public IActionResult getstockprice(string code,string startdate,string enddate)
        {
            var result = _stockBL.get(code, startdate, enddate);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No Data Found");
        }
    }
}
