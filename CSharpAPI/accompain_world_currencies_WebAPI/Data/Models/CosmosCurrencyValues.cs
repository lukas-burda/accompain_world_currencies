using accompain_world_currencies_WebAPI.Application.Models;
using System;
using System.Collections.Generic;

namespace accompain_world_currencies_WebAPI.Data.Models
{
    public class CosmosCurrencyValues
    {
        public List<Currency> Currencies { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
