using System;
using System.Threading.Tasks;
using FakeRestAPI.Models;

namespace FakeRestAPI.Domain.Interfaces
{
    public interface IUsersRepo : IGeneralAsyncRepo<UsersModel>
    {
        Task<string> UserRegister(UsersModel user, string password);
        Task<Object> UserLogin(string userName, string password);
        Task<bool> UserExist(string userName);
    }
}
