using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class CurrenciesAPIServices : ICurrenciesApiServices
    {
        async public void GetAvailableCurrencies()
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3333/avaiablecurrencies");

            var response = await client.SendAsync(request);

            var data = response.Content;

            Console.Write(data);
        }

        public Currency GetCurrenciesByDate(string basecurrencycode, string date)
        {
            throw new System.NotImplementedException();
        }

        public Currency GetCurrencyConversion(string basecurrencycode, string currencycode)
        {
            throw new System.NotImplementedException();
        }
    }
}
