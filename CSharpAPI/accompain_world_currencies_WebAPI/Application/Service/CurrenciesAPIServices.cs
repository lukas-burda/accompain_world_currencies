using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class CurrenciesAPIServices : ICurrenciesApiServices
    {
        public async System.Threading.Tasks.Task<string[]> GetAvailableCurrenciesAsync()
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3333/availablecurrencies");

            var response = await client.SendAsync(request);

            var data = response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject(data.Result);



            return ;

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
