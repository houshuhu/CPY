using System;

namespace CPy.Domain.Entities.Audit
{
    public interface ICreate
    {
        DateTime CreateTime { get; set; }
    }
}