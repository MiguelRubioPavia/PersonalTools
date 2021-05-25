using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext dataContext)
        {
            this.repositoryContext = dataContext;
        }

        public virtual IQueryable<T> FindAll(bool trackChanges = false) 
            => trackChanges ? repositoryContext.Set<T>() : repositoryContext.Set<T>().AsNoTracking();

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
            => trackChanges ? repositoryContext.Set<T>().Where(expression) : repositoryContext.Set<T>().Where(expression).AsNoTracking();

        public void Insert(T entity) => repositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => repositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);
    }
}
