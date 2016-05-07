using UDomain.Models;
using URepository.Repository;
using URepository.Uow;

namespace UService.Repositories
{
    public interface ISpecimenRepository
    {
        void Save();
    }

    public class SpecimenRepository :EFRepositoryBase<Specimen>, ISpecimenRepository
    {

        public void Save()
        {
            var specimen = new Specimen() {SNo = "S"};
            Insert(specimen,false);
        }

        public SpecimenRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}