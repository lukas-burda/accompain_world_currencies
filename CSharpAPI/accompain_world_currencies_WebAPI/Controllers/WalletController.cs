using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletServices _services;
        private readonly ICurrenciesApiServices _currenciesApiServices;

        public WalletController(IWalletServices walletServices, ICurrenciesApiServices currenciesApiServices)
        {
            _services = walletServices;
            _currenciesApiServices = currenciesApiServices;
        }

        // GET api/<WalletController>/availablecurrencies
        
        [HttpGet("availablecurrencies")]
        public Task<List<Currency>> GetAvailableCurrencies()
        {
            return _currenciesApiServices.GetAvailableCurrenciesAsync();
        }

        [HttpGet("currenciesbydate/{basecurrencycode}/{date}")]
        public Task<Wallet> GetCurrenciesByDate(string basecurrencycode, string date)
        {
            return _currenciesApiServices.GetCurrenciesByDate(basecurrencycode, date);
        }

        [HttpGet("currencyconversion/{basecurrencycode}/{CurrencyCode}")]
        public Task<string> GetCurrencyConversion(string basecurrencycode, string CurrencyCode)
        {
            return _currenciesApiServices.GetCurrencyConversion(basecurrencycode, CurrencyCode);
        }

        // GET api/<WalletController>/<id>
        [HttpGet("{id}")]
        public Wallet Get(int id)
        {
            return _services.GetById(id);
        }

        // POST api/<WalletController>
        [HttpPost]
        public void Post([FromBody] Wallet value)
        {
            _services.Save(value);
        }

        // PUT api/<WalletController>/5
        [HttpPut]
        public void Put([FromBody] Wallet value)
        {
            _services.Update(value);
        }

        // DELETE api/<WalletController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
