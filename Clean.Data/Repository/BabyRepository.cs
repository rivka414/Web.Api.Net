using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repository
{
    public class BabyRepository : Repository<Baby>, IBabyRepository
    {
        public BabyRepository(DataContext context) : base(context) { }

        // דריסה אסינכרונית של GetAll
        public override async Task<IEnumerable<Baby>> GetAllAsync()
        {
            return await _dbSet
                .Include(b => b.Appointments)
                .ToListAsync();
        }

        // דריסה אסינכרונית של GetById
        public override async Task<Baby?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Appointments)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}