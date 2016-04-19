using System;

namespace CPy.Domain.Entities.Audit
{
    public class AuditEntity<TPrimaryKey> : Entity<TPrimaryKey>, IAuditEntity<TPrimaryKey>
    {
        public bool IsDelete { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}