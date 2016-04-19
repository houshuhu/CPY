using System;
using System.Data.Entity.ModelConfiguration;
using CPy.Model.Models.User;

namespace CPy.Model.FluentAPI.User
{
    public class SysModuleEntityTypeConfiguration : BaseEntityTypeConfiguration<SysModule>
    {
        public SysModuleEntityTypeConfiguration()
        {
            HasMany(t => t.SysFunctions).WithRequired(t => t.SysModule).HasForeignKey(t => t.SysModuleId);
        }
    }
}