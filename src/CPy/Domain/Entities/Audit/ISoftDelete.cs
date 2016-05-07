using System;

namespace CPy.Domain.Entities.Audit
{
    public interface ISoftDelete
    {
        bool IsDelete { get; set; }
        DateTime? DeleteTime { get; set; }
    }
}