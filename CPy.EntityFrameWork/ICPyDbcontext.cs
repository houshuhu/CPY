using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CPy.Model.Models.User;

namespace CPy.EntityFrameWork
{
    public interface ICPyDbContext
    {
        #region Method
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        void Dispose();
        #endregion


        #region Model
        DbSet<SysUser> SysUsers { get; set; }
        DbSet<SysRole> SysRoles { get; set; }
        DbSet<SysModule> SysModules { get; set; }
        DbSet<SysFunction> SysFunctions { get; set; }
        #endregion
    }
}