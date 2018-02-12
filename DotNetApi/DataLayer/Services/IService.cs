using System.Threading.Tasks;
using CorePOC.Model;

namespace CorePOC.DataLayer.Services
{
    public interface IService
    {
        string AddConsumer(Consumer consumer);
        Task<string> AddConsumerAsync(Consumer consumer);

        string GetConsumerDetails(Consumer consumer);

        Task<string> GetConsumerDetailsAsync(Consumer consumer);
        string AddCardDetails(Card card);
        string GetCardDetails(Card card);
        string UpdateCardDetails(Card card);
        bool IsAuthorized(Auth auth);
   }
}