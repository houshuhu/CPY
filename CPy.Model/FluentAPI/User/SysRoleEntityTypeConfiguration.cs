using System.Data.Entity.ModelConfiguration;
using CPy.Model.Models.Admin;

namespace CPy.Model.FluentAPI.User
{
    public class SysRoleEntityTypeConfiguration : BaseEntityTypeConfiguration<SysRole>
    {
        public SysRoleEntityTypeConfiguration()
        {
            HasMany(t => t.SysFunctions).WithMany(t => t.SysRoles).Map(t =>
            {
                t.MapLeftKey("SysRoleId");
                t.MapRightKey("SysFunctionId");
                t.ToTable("SysRoleRSysFunction");
            });
        }
    }
}