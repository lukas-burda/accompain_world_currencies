﻿using accompain_world_currencies_WebAPI.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface ICurrenciesApiServices
    {
        public Task<List<Currency>> GetAvailableCurrenciesAsync();
        public Currency GetCurrenciesByDate(string basecurrencycode, string date);
        public Currency GetCurrencyConversion(string basecurrencycode, string currencycode);

    }
}
