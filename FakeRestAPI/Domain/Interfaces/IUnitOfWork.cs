using System;
namespace FakeRestAPI.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepo Users { get; }
        IAuthorsRepo Authors { get; }
        IBooksRepo Books { get; }
        IActivitiesRepo Activities { get; }
        void SaveData();
    }
}
