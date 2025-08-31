using Notero.Application.Contracts.Persistance;
using Notero.Persistance.Context;

namespace Notero.Persistance.Concrete
{
    public class UnitOfWork(AppDbContext _context ) : IUnitOfWork
    {
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
