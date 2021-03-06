using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBoqDbContext
    {
        DbSet<WorkOrder> workOrders { get; set; }
        DbSet<StandardSpecification> standardSpecifications { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
