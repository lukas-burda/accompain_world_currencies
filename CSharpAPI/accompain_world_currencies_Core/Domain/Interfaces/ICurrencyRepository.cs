using accompain_world_currencies_Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Core.Domain.Interfaces
{
    public interface ICurrencyRepository
    {
        public Currency Save(Currency obj);
        public Currency Update(Currency obj);
        public Currency Delete(int id);
        public Currency GetById(int id);
    }
}
