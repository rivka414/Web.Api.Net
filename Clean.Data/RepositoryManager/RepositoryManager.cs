using Clean.Core.Repositories;
using Clean.Core.Data;
using System.Threading.Tasks;

namespace Clean.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IAppointmentRepository Appointments { get; }
        public IBabyRepository Babies { get; }
        public INurseRepository Nurses { get; }

        public RepositoryManager(DataContext context, IAppointmentRepository appointments, IBabyRepository babies, INurseRepository nurses)
        {
            _context = context;
            Appointments = appointments;
            Babies = babies;
            Nurses = nurses;
        }

        // מימוש אסינכרוני לשמירה
        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}