using UDomain.Models;
using URepository.Repository;
using URepository.Uow;

namespace UService.Repositories
{
    public interface IRole1Repository:IRepository<Role>
    {
         
    }

    public class Role1Repository : EFRepositoryBase<Role>, IRole1Repository
    {
        public Role1Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}