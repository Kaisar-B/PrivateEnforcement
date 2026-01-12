using Data.Domain.DataAccessLayer.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.DAL
{
    internal class RepositorySession : IRepositorySession
    {
        private DatabaseContext _context;
        private IRepository _repository;

        public RepositorySession(DatabaseContext context)
        {
            _context = context;
            _repository = new DatabaseProvider.Repository(_context);
        }
        public IDbContextTransaction CreateTransaction<TResult>(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return _context.Database.BeginTransaction(isolationLevel);
        }

        public TResult StartTransaction<TResult>(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
