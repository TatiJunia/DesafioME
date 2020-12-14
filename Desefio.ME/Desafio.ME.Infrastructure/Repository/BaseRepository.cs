using Desafio.ME.Domain.Model;
using Desafio.ME.Domain.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.ME.Infrastructure.Repository
{
    public class BaseRepository<T> where T : Entity
    {
        private readonly EFContext _context;

        public BaseRepository(EFContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(T entity)
        {
            this._context.Add<T>(entity);
        }

        public void Delete(T entity)
        {
            this._context.Remove<T>(entity);
        }

        public T GetById(long id)
        {
            return this._context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<T> List()
        {
            return this._context.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            this._context.Update<T>(entity);
        }
    }
}