using System.Threading.Tasks;
using CorePOC.Model;

namespace CorePOC.DataLayer.Repositories
{
    public interface IRepository
    {
        string AddConsumer(Consumer consumer);
        Task<string> AddConsumerAsync(Consumer consumer);
        string GetConsumerDetails(Consumer consumer);
        Task<string> GetConsumerDetailsAsync(Consumer consumer);
        string AddCardDetails(Card card);
        Task<string> AddCardDetailsAsync(Card card);
        string GetCardDetails(Card card);
        Task<string> GetCardDetailsAsync(Card card);
        string UpdateCardDetails(Card card);
        Task<string> UpdateCardDetailsAsync(Card card);
        bool IsAuthorised(Auth auth);
    }
}