using accompain_world_currencies_WebAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface IWalletServices
    {
        public Wallet Save(Wallet obj);
        public Wallet Update(Wallet obj);
        public Wallet Delete(int id);
        public Wallet GetById(int id);
    }
}
