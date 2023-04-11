using eTickets.Models;

namespace eTickets.Base {
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new() {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task AddAsync(T newEntity);

        Task EditAsync(int id, T newEntity);

        Task DeleteAsync(int id);
    }
}
