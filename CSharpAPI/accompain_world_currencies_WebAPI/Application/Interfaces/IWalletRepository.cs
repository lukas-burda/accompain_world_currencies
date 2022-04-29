using accompain_world_currencies_WebAPI.Application.Models;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface IWalletRepository
    {
        public Wallet Delete(int id);

        public Wallet GetById(int id);

        public Wallet Save(Wallet obj);

        public Wallet Update(Wallet obj);
    }
}
