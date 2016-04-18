using System;

namespace UDataCore.Uow
{
    public interface IUow:IDisposable
    {
        int Commit(); 
    }
}