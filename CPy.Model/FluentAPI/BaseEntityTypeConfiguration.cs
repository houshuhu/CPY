using System;
using System.Data.Entity.ModelConfiguration;
using CPy.Domain.Entities;

namespace CPy.Model.FluentAPI
{
    public class BaseEntityTypeConfiguration<TModel> : EntityTypeConfiguration<TModel> where TModel : class ,IEntity<Guid>
    {

    }
}