using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FakeRestAPI.DataAccess;
using FakeRestAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FakeRestAPI.Infraestructure.Repositories
{
    public class GeneralAsyncRepo<T> : IGeneralAsyncRepo<T> where T : class
    {
        protected AppDbContext _context;

        protected IConfiguration _configuration;

        internal DbSet<T> _dbSet;

        public GeneralAsyncRepo(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _configuration = configuration;
        }

        public async Task AddT(T model)
        {
            await _dbSet.AddAsync(model);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeproperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeproperties != null)
            {
                foreach (var item in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
                
            }

            if (orderby != null)
            {
                return await orderby(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string includeproperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeproperties != null)
            {
                foreach (var item in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetT(int id, string includeproperties = null)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveRangeT(IEnumerable<T> modelList)
        {
            _dbSet.RemoveRange(modelList);
        }

        public async Task RemoveT(int id)
        {
            var model = await _dbSet.FindAsync(id);
            await RemoveT(model);
            
        }

        public async Task RemoveT(T model)
        {
            _dbSet.Remove(model);
        }
    }
}
