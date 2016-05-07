using UDataCore;
using UDomain.Models;

namespace UService.Repositories
{
    public interface IRoleRepository
    {
        void Save();
    }

    public class RoleRepository : IRoleRepository
    {
        private readonly IUDbContext _dbContext;

        public RoleRepository(IUDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            int i = 1;
        }
    }
}