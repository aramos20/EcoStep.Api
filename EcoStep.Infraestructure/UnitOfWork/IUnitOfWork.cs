using EcoStep.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace EcoStep.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task<int> Complete(CancellationToken cancellationToken);
    void Dispose();
    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}