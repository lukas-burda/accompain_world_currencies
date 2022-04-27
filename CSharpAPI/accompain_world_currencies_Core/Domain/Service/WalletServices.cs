using accompain_world_currencies_Core.Domain.Interfaces;
using accompain_world_currencies_Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Core.Domain.Service
{
    public class WalletServices
    {
        private readonly IWalletRepository _walletRepository;
        public Wallet Save(Wallet wallet)
        {
            return _walletRepository.Save(wallet);
        }
        public Wallet Update(Wallet obj)
        {
            return _walletRepository.Update(obj);
        }

        public Wallet Delete(int id)
        {
            return _walletRepository.Delete(id);
        }
        public Wallet GetById(int id)
        {
            return _walletRepository.GetById(id);
        }
    }
}
