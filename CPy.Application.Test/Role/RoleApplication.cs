using Abp.Application.Services;

namespace CPy.Application.Test.Role
{
    public interface IRoleApplication : IApplicationService
    {
        void Save();
    }

    public class RoleApplication : ApplicationService,IRoleApplication
    {

        public void Save()
        {
            int a = 1;
        }
    }
}