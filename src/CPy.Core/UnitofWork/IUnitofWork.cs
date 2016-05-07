using System;
using CPy.ResultDto.ExcuteResult;

namespace CPy.Core.UnitofWork
{
    public interface IUnitofWork:IDisposable
    {
        WebExcuteResult<EmptyResult> Commit();  
    }
}