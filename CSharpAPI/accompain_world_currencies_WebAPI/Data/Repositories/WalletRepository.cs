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
        private List<Wallet> wallets = new List<Wallet>();


        public Wallet Delete(int id)
        {
            try
            {
                var a = GetById(id);
                wallets.RemoveAll(x => x.Id == id);
                return a;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Wallet GetById(int id)
        {
            try
            {
                return wallets.Find(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
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
                    wallets.Add(obj);
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
