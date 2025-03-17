using CarDealership.DataAccess.Data;
using CarDealership.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                //foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    query = query.Include(property);
                //}

                query = query.Include(includeProperties);
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                //foreach(var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    query = query.Include(property);
                //}
                query = query.Include(includeProperties);
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
