using Desafio.ME.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.ME.Domain.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> List();
        T GetById(long Id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
