using eTickets.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services {
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
