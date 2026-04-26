using Clean.Core.Entities;
using Clean.Core.Repositories;

namespace Clean.Service.Services
{
    public class BabyService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BabyService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Baby>> GetAllAsync() =>
            await _repositoryManager.Babies.GetAllAsync();

        public async Task<Baby?> GetByIdAsync(int id) =>
            await _repositoryManager.Babies.GetByIdAsync(id);

        public async Task AddAsync(Baby baby)
        {
            await _repositoryManager.Babies.AddAsync(baby);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int id, Baby baby)
        {
            var exist = await _repositoryManager.Babies.GetByIdAsync(id);
            if (exist != null)
            {
                exist.FirstName = baby.FirstName;
                exist.LastName = baby.LastName;
                exist.DateOfBirth = baby.DateOfBirth;
                exist.Status = baby.Status;
                await _repositoryManager.SaveAsync();
            }
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var exist = await _repositoryManager.Babies.GetByIdAsync(id);
            if (exist != null)
            {
                exist.Status = status;
                await _repositoryManager.SaveAsync();
            }
        }
    }
}