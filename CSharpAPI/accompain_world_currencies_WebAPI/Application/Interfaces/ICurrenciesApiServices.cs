using accompain_world_currencies_WebAPI.Application.Models;
using System.Collections.Generic;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface ICurrenciesApiServices
    {
        public void GetAvailableCurrencies();
        public Currency GetCurrenciesByDate(string basecurrencycode, string date);
        public Currency GetCurrencyConversion(string basecurrencycode, string currencycode);

    }
}
