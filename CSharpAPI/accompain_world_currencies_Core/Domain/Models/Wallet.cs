using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Core.Domain.Models
{
    public class Wallet
    {
        public double Value { get; set; }
        public string Name { get; set; }
        public string CurrencyCodeBased { get; set; }
        public List<Currency> accompaniedCurrencies { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
