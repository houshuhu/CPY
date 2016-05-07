using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UDomain.Models;

namespace UDataCore
{
    public interface IUDbContext
    {
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        void Dispose();
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Specimen> Specimens { get; set; }
    }
}