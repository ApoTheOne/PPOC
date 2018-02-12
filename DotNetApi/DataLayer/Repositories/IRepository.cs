using CorePOC.Model;

namespace CorePOC.DataLayer.Repositories
{
    public interface IRepository
    {
        string AddConsumer(Consumer consumer);
        string GetConsumerDetails(Consumer consumer);
        string AddCardDetails(Card card);
        string GetCardDetails(Card card);
        string UpdateCardDetails(Card card);
        bool IsAuthorised(Auth auth);
    }
}