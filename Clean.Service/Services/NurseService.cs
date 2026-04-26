using Clean.Core.Entities;
using Clean.Core.Repositories;

namespace Clean.Service.Services
{
    public class NurseService
    {
        private readonly IRepositoryManager _repositoryManager;

        public NurseService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        // מחזיר משימה עם רשימת אחיות
        public async Task<IEnumerable<Nurse>> GetAllAsync() =>
            await _repositoryManager.Nurses.GetAllAsync();

        // מחזיר משימה עם אחות ספציפית
        public async Task<Nurse?> GetByIdAsync(int id) =>
            await _repositoryManager.Nurses.GetByIdAsync(id);

        // הוספה אסינכרונית ושמירה
        public async Task AddAsync(Nurse nurse)
        {
            await _repositoryManager.Nurses.AddAsync(nurse);
            await _repositoryManager.SaveAsync();
        }

        // עדכון אסינכרוני
        public async Task UpdateAsync(int id, Nurse updatedNurse)
        {
            var exist = await _repositoryManager.Nurses.GetByIdAsync(id);
            if (exist != null)
            {
                exist.FirstName = updatedNurse.FirstName;
                exist.LastName = updatedNurse.LastName;
                exist.Role = updatedNurse.Role;
                exist.Status = updatedNurse.Status;

                await _repositoryManager.SaveAsync();
            }
        }

        // עדכון סטטוס אסינכרוני
        public async Task UpdateStatusAsync(int id, string status)
        {
            var exist = await _repositoryManager.Nurses.GetByIdAsync(id);
            if (exist != null)
            {
                exist.Status = status;
                await _repositoryManager.SaveAsync();
            }
        }
    }
}