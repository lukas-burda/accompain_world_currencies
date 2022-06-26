using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using accompain_world_currencies_WebAPI.Data.Models;
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
        private readonly IRabbitQueueServices _rabbitServices;

        public WalletController(IWalletServices walletServices, ICurrenciesApiServices currenciesApiServices, IRabbitQueueServices rabbitQueueServices)
        {
            _services = walletServices;
            _currenciesApiServices = currenciesApiServices;
            _rabbitServices = rabbitQueueServices;
        }

        // GET api/<WalletController>/availablecurrencies

        [HttpGet("enqueuedcurrencies")]
        public CosmosCurrencyValues GetEnqueuedCurrencies() 
        {
            return _rabbitServices.ConsumeQueue();
        }

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
            _services.Delete(id);
        }
    }
}
