using System.Threading.Tasks;

namespace Clean.Core.Repositories
{
    public interface IRepositoryManager
    {
        IAppointmentRepository Appointments { get; }
        IBabyRepository Babies { get; }
        INurseRepository Nurses { get; }

        // הפעולה הכי חשובה - שמירה אסינכרונית מול ה-DB
        Task SaveAsync();
    }
}