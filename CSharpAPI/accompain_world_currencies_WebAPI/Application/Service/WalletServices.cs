using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using accompain_world_currencies_WebAPI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Application.Service
{
    public class WalletServices : IWalletServices
    {
        private readonly IWalletRepository _repository;
        public WalletServices(IWalletRepository walletRepository)
        {
            _repository = walletRepository;
        }

        public Wallet Save(Wallet wallet)
        {
            return _repository.Save(wallet);
        }
        public Wallet Update(Wallet obj)
        {
            return _repository.Update(obj);
        }

        public Wallet Delete(int id)
        {
            return _repository.Delete(id);
        }
        public Wallet GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
