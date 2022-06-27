using accompain_world_currencies_WebAPI.Data.Models;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface ICurrencyValueRepository
    {
        public bool Delete(string date);

        public CurrencyValues GetByDate(int id);

        public bool Save(CurrencyValues obj);

        public CurrencyValues Update(CurrencyValues obj);
    }
}
