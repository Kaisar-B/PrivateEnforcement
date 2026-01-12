using Data.Domain.DataAccessLayer.GenericRepository;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace Database.Repository.DatabaseProvider
{
    internal class Repository : IRepository
    {
        private DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public TResult GetById<TResult>(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> GetAll<TResult>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> FindSet<TResult>(Expression<Func<TResult, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Include<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction CreateTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return _context.Database.BeginTransaction(isolationLevel);
        }
    }
}
