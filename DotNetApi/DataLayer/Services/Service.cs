using CorePOC.DataLayer.UnitOfWork;
using CorePOC.Model;

namespace CorePOC.DataLayer.Services
{
    public class Service : IService
    {
        IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        
        public string AddConsumer(Consumer consumer)
        {
            return _unitOfWork.Repository.AddConsumer(consumer);
        }

        public string GetConsumerDetails(Consumer consumer)
        {
            return _unitOfWork.Repository.GetConsumerDetails(consumer);
        }
        public string AddCardDetails(Card card)
        {
           return _unitOfWork.Repository.AddCardDetails(card);
        }

        public string GetCardDetails(Card card)
        {
            return _unitOfWork.Repository.GetCardDetails(card);
        }

        public string UpdateCardDetails(Card card)
        {
            return _unitOfWork.Repository.UpdateCardDetails(card);
        }

        public bool IsAuthorized(Auth auth)
        {
            return _unitOfWork.Repository.IsAuthorised(auth);
        }

        // public string GetConsumerDetails(Consumer consumer) => _unitOfWork.Repository.GetConsumerDetails(consumer);
    }
}