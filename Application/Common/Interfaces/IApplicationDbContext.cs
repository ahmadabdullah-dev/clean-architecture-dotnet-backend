using Domain.Entities.User.Base;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserEntity> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
