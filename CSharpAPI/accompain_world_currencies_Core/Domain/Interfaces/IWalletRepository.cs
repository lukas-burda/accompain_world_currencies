using accompain_world_currencies_Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Core.Domain.Interfaces
{
    public interface IWalletRepository
    {
        public Wallet Save(Wallet obj);
        public Wallet Update(Wallet obj);
        public Wallet Delete(int id);
        public Wallet GetById(int id);
    }
}
