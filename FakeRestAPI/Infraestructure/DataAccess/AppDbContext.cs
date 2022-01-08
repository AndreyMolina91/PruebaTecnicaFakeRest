using FakeRestAPI.Domain.Models;
using FakeRestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeRestAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<ActivitiesModel> Activities { get; set; }
        public DbSet<AuthorsModel> Authors { get; set; }
        public DbSet<BooksModel> Books { get; set; }
        public DbSet<CoverPhotosModel> CoverPhotos { get; set; }
    }
}
