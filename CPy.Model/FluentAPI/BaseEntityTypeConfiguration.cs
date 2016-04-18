using System;
using Abp.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CPy.Model.FluentAPI
{
    public class BaseEntityTypeConfiguration<TModel> : EntityTypeConfiguration<TModel> where TModel : Entity<Guid> 
    {
         
    }
}