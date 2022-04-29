using accompain_world_currencies_WebAPI.Application.Interfaces;
using accompain_world_currencies_WebAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_WebAPI.Data.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private List<Wallet> wallets;

        public Wallet Delete(int id)
        {
            try
            {
                var a = GetById(id);
                wallets.Remove(a);
                return a;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Wallet GetById(int id)
        {
            return wallets.Find(x => x.Id == id);
        }

        public Wallet Save(Wallet obj)
        {
            try
            {
                wallets.Add(obj);
                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Wallet Update(Wallet obj)
        {
            try
            {
                if (GetById(obj.Id) != null)
                {
                    wallets.Remove(GetById(obj.Id));
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
