using Clean.Core.Entities;
using Clean.Core.Repositories;

namespace Clean.Service.Services
{
    public class AppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AppointmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
            await _repositoryManager.Appointments.GetAllAsync();

        public async Task<Appointment?> GetByIdAsync(int id) =>
            await _repositoryManager.Appointments.GetByIdAsync(id);

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date) =>
            await _repositoryManager.Appointments.GetByDateAsync(date);

        public async Task AddAsync(Appointment appointment)
        {
            await _repositoryManager.Appointments.AddAsync(appointment);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAsync(int id, Appointment updatedAppointment)
        {
            var exist = await _repositoryManager.Appointments.GetByIdAsync(id);
            if (exist != null)
            {
                exist.BabyId = updatedAppointment.BabyId;
                exist.NurseId = updatedAppointment.NurseId;
                exist.Date = updatedAppointment.Date;
                exist.Status = updatedAppointment.Status;
                exist.Notes = updatedAppointment.Notes;

                await _repositoryManager.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _repositoryManager.Appointments.GetByIdAsync(id);
            if (exist != null)
            {
                _repositoryManager.Appointments.Delete(exist); // מחיקה לרוב אינה אסינכרונית ב-EF, רק השמירה
                await _repositoryManager.SaveAsync();
            }
        }
    }
}