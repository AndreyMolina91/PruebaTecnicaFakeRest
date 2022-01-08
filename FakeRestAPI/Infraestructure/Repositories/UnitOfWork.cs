using System;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FakeRestAPI.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public IUsersRepo Users { get; private set; }
        public IBooksRepo Books { get; private set; }
        public IAuthorsRepo Authors { get; private set; }
        public IActivitiesRepo Activities { get; private set; }

        public UnitOfWork(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            Users = new UsersRepo(_context, _configuration);
            Authors = new AuthorsRepo(_context, _configuration);
            Books = new BooksRepo(_context, _configuration);
            Activities = new ActivitiesRepo(_context, _configuration);
        }

        

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveData()
        {
            _context.SaveChanges();
        }
    }
}
