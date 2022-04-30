using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class CurrenciesAPIServices : ICurrenciesApiServices
    {
        public async Task<List<Currency>> GetAvailableCurrenciesAsync()
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3333/availablecurrencies");

            var response = await client.SendAsync(request);

            var data = response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(data.Result);

            var currencyList = new List<Currency>();

            foreach (var item in json)
            {
                foreach (var i in item)
                {
                    for (int x = 0; x < 209; x++)
                    {
                        currencyList.Add(new Currency { 
                            Name = i[x]["name"],
                            Code = i[x]["value"]
                        });
                    }
                }
            }

            return currencyList;

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
