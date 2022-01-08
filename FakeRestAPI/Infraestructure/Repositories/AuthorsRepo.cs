using System;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Interfaces;
using FakeRestAPI.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace FakeRestAPI.Infraestructure.Repositories
{
    public class AuthorsRepo : GeneralAsyncRepo<AuthorsModel>, IAuthorsRepo
    {
        public AuthorsRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
