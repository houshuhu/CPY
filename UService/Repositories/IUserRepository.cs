using UDataCore;
using UDomain.Models;

namespace UService.Repositories
{
    public interface IUserRepository
    {
        void Save();
    }

    public class UserRepository :IUserRepository
    {
        private readonly IUDbContext _dbContext;

        public UserRepository(IUDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            int i = 0;
        }
    }
}