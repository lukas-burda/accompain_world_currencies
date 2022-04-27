using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Data.Models
{
    public class WalletDTO
    {
        public double MoneyQuantity { get; set; }
        public string Name { get; set; }
        public string BasedCurrencyCode { get; set; }

        public List<CurrencyDTO> FavoriteCurrencies { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
