using System.Data.Entity.ModelConfiguration;
using CPy.Model.Models.Admin;

namespace CPy.Model.FluentAPI.User
{
    public class SysUserEntityTypeConfiguration : BaseEntityTypeConfiguration<SysUser>
    {
        public SysUserEntityTypeConfiguration()
        {
            this.HasMany(t => t.SysRoles).WithMany(t => t.SysUsers).Map(t =>
            {
                t.MapLeftKey("SysUserId");
                t.MapRightKey("SysRoleId");
                t.ToTable("SysUserRSysRole");
            });
        }
    }
}
