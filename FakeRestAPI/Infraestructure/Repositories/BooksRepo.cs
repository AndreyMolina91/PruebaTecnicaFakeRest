using System;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Interfaces;
using FakeRestAPI.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace FakeRestAPI.Infraestructure.Repositories
{
    public class BooksRepo : GeneralAsyncRepo<BooksModel>, IBooksRepo
    {
        public BooksRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
