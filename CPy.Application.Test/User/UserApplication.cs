using Abp.Application.Services;

namespace CPy.Application.Test.User
{
    public interface IUserApplication : IApplicationService
    {
        void Save();
    }

    public class UserApplication : ApplicationService,IUserApplication
    {

        public void Save()
        {
            int a = 1;
        }
    }
    public class UserApplication2 : ApplicationService, IUserApplication
    {

        public void Save()
        {
            int a = 1;
        }
    }
}