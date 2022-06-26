using accompain_world_currencies_WebAPI.Data.Models;

namespace accompain_world_currencies_WebAPI.Application.Interfaces
{
    public interface IRabbitQueueServices
    {
        public CosmosCurrencyValues ConsumeQueue();
    }
}
