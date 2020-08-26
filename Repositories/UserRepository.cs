using Dess.DbContexts;
using Dess.Entities;

namespace Dess.Repositories
{
    public class UserRepository : RepositoryBase<User, DessDbContext>, IUserRepository
    {
        public UserRepository(DessDbContext context) : base(context) {}
    }
}