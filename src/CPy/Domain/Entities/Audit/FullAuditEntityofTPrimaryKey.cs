using System;

namespace CPy.Domain.Entities.Audit
{
    public class FullAuditEntity<TPrimaryKey> :AuditEntity<TPrimaryKey>, IFullAuditEntity<TPrimaryKey>
    {
        public TPrimaryKey CreateUserId { get; set; }

        public TPrimaryKey UpdateUserId { get; set; }

        public TPrimaryKey DeleteUserId { get; set; }
    }
}