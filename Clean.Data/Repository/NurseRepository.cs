using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repository
{
    public class NurseRepository : Repository<Nurse>, INurseRepository
    {
        public NurseRepository(DataContext context) : base(context) { }

        public override async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            return await _dbSet
                .Include(n => n.Appointments)
                .ToListAsync();
        }

        public override async Task<Nurse?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(n => n.Appointments)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}