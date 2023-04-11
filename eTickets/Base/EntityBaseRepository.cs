using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Base {
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new() {
        public readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context){
            _context = context;
        }

        public async Task AddAsync(T newEntity) {
            await _context.Set<T>().AddAsync(newEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, T newEntity) {
            EntityEntry entityEntry = _context.Entry<T>(newEntity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
    }
}
