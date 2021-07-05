using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class BoqDbContext : DbContext, IBoqDbContext
    {
        public BoqDbContext(DbContextOptions<BoqDbContext> options)
         : base(options)
        {
        }
        public DbSet<WorkOrder> workOrders { get; set ; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedBy = _currentUserService.UserId;
            //            entry.Entity.Created = _dateTime.Now;
            //            break;
            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
            //            entry.Entity.LastModified = _dateTime.Now;
            //            break;
            //    }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
