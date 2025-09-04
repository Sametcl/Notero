using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Notero.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notero.Persistance.Interceptors
{
    public class AuditDBContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
        {
            {
                EntityState.Added, AddedBehavior
            },
            {
                EntityState.Modified, ModifiedBehavior
            }
        };


        private static void AddedBehavior(DbContext context, BaseEntity baseEntity)
        {
            context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified = false;
            baseEntity.CreatedAt = DateTime.UtcNow;
        }


        private static void ModifiedBehavior(DbContext context, BaseEntity baseEntity)
        {
            context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
            baseEntity.UpdatedAt = DateTime.UtcNow;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is not BaseEntity baseEntity)
                {
                    continue;
                }
                if (entry.State is not (EntityState.Added or EntityState.Modified))
                {
                    continue;
                }
                Behaviors[entry.State](eventData.Context, baseEntity);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
