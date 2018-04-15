using System.Threading.Tasks;
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

        public async Task<string> AddConsumerAsync(Consumer consumer)
        {
            return await _unitOfWork.Repository.AddConsumerAsync(consumer);
        }

        public string GetConsumerDetails(Consumer consumer)
        {
            return _unitOfWork.Repository.GetConsumerDetails(consumer);
        }

        public async Task<string> GetConsumerDetailsAsync(Consumer consumer)
        {
            return await _unitOfWork.Repository.GetConsumerDetailsAsync(consumer);
        }

        public string AddCardDetails(Card card)
        {
           return _unitOfWork.Repository.AddCardDetails(card);
        }

        public async Task<string> AddCardDetailsAsync(Card card)
        {
           return await _unitOfWork.Repository.AddCardDetailsAsync(card);
        }

        public string GetCardDetails(Card card)
        {
            return _unitOfWork.Repository.GetCardDetails(card);
        }
        public async Task<string> GetCardDetailsAsync(Card card)
        {
            return await _unitOfWork.Repository.GetCardDetailsAsync(card);
        }

        public string UpdateCardDetails(Card card)
        {
            return _unitOfWork.Repository.UpdateCardDetails(card);
        }

        public async Task<string> UpdateCardDetailsAsync(Card card)
        {
            return await _unitOfWork.Repository.UpdateCardDetailsAsync(card);
        }

        public bool IsAuthorized(Auth auth)
        {
            return _unitOfWork.Repository.IsAuthorised(auth);
        }

        // public string GetConsumerDetails(Consumer consumer) => _unitOfWork.Repository.GetConsumerDetails(consumer);
    }
}