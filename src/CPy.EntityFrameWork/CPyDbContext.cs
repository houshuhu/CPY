using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using CPy.Model.FluentAPI;
using CPy.Model.FluentAPI.User;
using CPy.Model.Models.Admin;

namespace CPy.EntityFrameWork
{
    public class CPyDbContext : DbContext, ICPyDbContext
    {
        public Guid Id = Guid.NewGuid();
        public CPyDbContext()
            : base("default")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(BaseEntityTypeConfiguration<>)).GetTypes();
            
            var registerTypes =types.Where(
                    t => t.IsClass && t.BaseType != null && t.BaseType.IsGenericType &&
                        t != typeof(BaseEntityTypeConfiguration<>)&&
                        t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>)).ToList();
            foreach (var registerType in registerTypes)
            {
                dynamic configurationInstance = Activator.CreateInstance(registerType);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            
            base.OnModelCreating(modelBuilder);
        }

        #region 实体

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysModule> SysModules { get; set; }
        public DbSet<SysFunction> SysFunctions { get; set; }

        #endregion

    }
}