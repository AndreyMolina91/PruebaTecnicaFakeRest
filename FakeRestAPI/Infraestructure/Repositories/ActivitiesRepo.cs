using System;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Interfaces;
using FakeRestAPI.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace FakeRestAPI.Infraestructure.Repositories
{
    public class ActivitiesRepo : GeneralAsyncRepo<ActivitiesModel>, IActivitiesRepo
    {
        public ActivitiesRepo(AppDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
