using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UDomain.Models;

namespace UDataCore
{
    public class UDbcontext:DbContext,IUDbContext
    {
        private static readonly string constring =
            System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public UDbcontext()
            : base("default")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        private Guid id = Guid.NewGuid();
        public Guid Id
        {
            get { return id; }
        }
    }
}