using System;

namespace CPy.Domain.Entities.Audit
{
    public interface IUpdate
    {
        DateTime? UpdateTime { get; set; }
    }
}