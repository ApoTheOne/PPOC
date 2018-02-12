using CorePOC.Model;

namespace CorePOC.DataLayer.Services
{
    public interface IService
    {
        string AddConsumer(Consumer consumer);
        string GetConsumerDetails(Consumer consumer);
        string AddCardDetails(Card card);
        string GetCardDetails(Card card);
        string UpdateCardDetails(Card card);
        bool IsAuthorized(Auth auth);
   }
}