// Clean.Core/Repositories/IAppointmentRepository.cs
using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        // שינוי ל-Task ושינוי השם ל-Async
        Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date);
    }
}