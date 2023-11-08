using Domain;
using Domain.Entities;
using Moneyon.Common.IOC;

namespace Service.Services
{
    
    public class RecievedDataService
    {
        private readonly IUnitOfWork _uw;
        public RecievedDataService(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task CreateData(RecievedData data)
        {
            await _uw.RecievedDataRepository.InsertAsync(data);
            await _uw.CommitAsync();
        }


    }
}
