using accompain_world_currencies_Core.Domain.Interfaces;
using accompain_world_currencies_Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accompain_world_currencies_Infraestructure.Data.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private static List<Wallet> wallets;

        public Wallet Delete(int id)
        {
            try
            {
                var a = this.GetById(id);
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
                if(this.GetById(obj.Id) != null)
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
