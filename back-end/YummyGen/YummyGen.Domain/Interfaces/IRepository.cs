﻿using System.Linq.Expressions;

namespace YummyGen.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task Delete(T entity);
        public Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        public Task<T> SingleByCondition(Expression<Func<T, bool>> expression);
        public Task<bool> AnyByCondition(Expression<Func<T, bool>> expression);
    }
}
