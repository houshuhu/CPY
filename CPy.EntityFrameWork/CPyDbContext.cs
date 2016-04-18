using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Abp.Domain.Entities;
using CPy.Model.FluentAPI;
using CPy.Model.Model.User;

namespace CPy.EntityFrameWork
{
    public class CPyDbContext:DbContext,ICPyDbcontext
    {
        public CPyDbContext()
            : base("default")
        {
        }
        public CPyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(BaseEntityTypeConfiguration<>)).GetTypes();
            var registerTypes =types.Where(
                    t =>
                        t != typeof(BaseEntityTypeConfiguration<>)&&
                        t.BaseType != null &&
                        t.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>));
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