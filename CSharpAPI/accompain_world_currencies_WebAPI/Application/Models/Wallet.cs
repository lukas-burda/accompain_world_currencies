using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public double MoneyQuantity { get; set; }
        public string Name { get; set; }
        public string BasedCurrencyCode { get; set; }
        public List<Currency> FavoriteCurrencyList { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
