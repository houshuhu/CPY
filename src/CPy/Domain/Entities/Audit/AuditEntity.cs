using System;

namespace CPy.Domain.Entities.Audit
{
    public  class AuditEntity : AuditEntity<Guid>, IAuditEntity
    {
        public AuditEntity():base()
        {
            Id = Guid.NewGuid();
        }

    }
}