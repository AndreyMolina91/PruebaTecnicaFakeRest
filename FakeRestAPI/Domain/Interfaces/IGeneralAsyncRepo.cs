using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FakeRestAPI.Domain.Interfaces
{

    public interface IGeneralAsyncRepo<T> where T : class
    {
        Task<T> GetT(int id, string includeproperties = null);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeproperties = null);

        Task<T> GetFirst(Expression<Func<T, bool>> filter = null,
            string includeproperties = null);

        Task AddT(T model);

        Task RemoveT(int id);

        Task RemoveT(T model);

        Task RemoveRangeT(IEnumerable<T> modelList);

    }

}