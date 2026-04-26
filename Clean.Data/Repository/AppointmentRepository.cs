using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Data;
using Microsoft.EntityFrameworkCore; // חובה בשביל Include

namespace Clean.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DataContext context) : base(context) { }

        public override async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _dbSet
                .Include(a => a.Baby)
                .Include(a => a.Nurse)
                .ToListAsync();
        }

        public override async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Baby)
                .Include(a => a.Nurse)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        {
            return await _dbSet
                .Include(a => a.Baby)
                .Include(a => a.Nurse)
                .Where(a => a.Date.Date == date.Date)
                .ToListAsync();
        }
    }
}