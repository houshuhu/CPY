using System;

namespace CPy.Core.UnitofWork
{
    public interface IUnitofWork:IDisposable
    {
        int Commit();  
    }
}