using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public string GetAvailableCurrencies()
        {
            _currenciesApiServices.GetAvailableCurrencies();
            return "";
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
            
        }

        // PUT api/<WalletController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WalletController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
