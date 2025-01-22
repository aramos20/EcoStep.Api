using EcoStep.Infrastructure.Data;
using EcoStep.Infrastructure.Repositories.Classes;
using EcoStep.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EcoStep.Infrastructure.UnitOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IUserRepository UserRepository { get; }

        public UnitOfWork
        (
            ApplicationDbContext dbContext,
            IUserRepository userRepository
            )
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            
        }

        public async Task<int> Complete(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
        {
            return await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
