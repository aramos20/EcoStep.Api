using EcoStep.Domain.Models;

namespace EcoStep.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> getUserByFirebaseId(string firebaseId);
}