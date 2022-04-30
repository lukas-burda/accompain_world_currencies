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
                        currencyList.Add(new Currency
                        {
                            Name = i[x]["name"],
                            Code = i[x]["value"]
                        });
                    }
                }
            }

            return currencyList;

        }

        public async Task<Wallet> GetCurrenciesByDate(string basecurrencycode, string date)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:3333/currenciesbydate/{basecurrencycode}/{date}");

            var response = await client.SendAsync(request);

            var data = response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(data.Result);

            var currencyList = new List<Currency>();

            foreach (var item in json)
            {
                foreach (var i in item)
                {
                    for (int x = 0; x < 207; x++)
                    {
                        currencyList.Add(new Currency
                        {
                            Name = i[x]["name"],
                            Code = i[x]["value"]
                        });
                    }
                }
            }

            var wallet = new Wallet
            {
                Name = "Minha Carteira",
                MoneyQuantity = 15610.50,
                BasedCurrencyCode = basecurrencycode,
                FavoriteCurrencyList = currencyList,
                LastUpdate = Convert.ToDateTime(date)
            };

            return wallet;

        }

        public async Task<string> GetCurrencyConversion(string basecurrencycode, string currencycode)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:3333/currencyconversion/{basecurrencycode}/{currencycode}");

            var response = await client.SendAsync(request);

            var data = response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(data.Result);

            var date = "";
            var value = "";

            foreach (var item in json)
            {
                foreach (var x in item)
                {
                    for (int y = 0; y < 1; y++)
                    {
                        date = x["date"];
                        value = x[$"{currencycode}"];
                    }
                }   
            }

            return $"Conversão de {basecurrencycode} para {currencycode} em {date} no valor {value}";

        }
    }
}
