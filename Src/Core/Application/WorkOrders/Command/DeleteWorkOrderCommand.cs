using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WorkOrders.Command
{
    public class DeleteWorkOrderCommand :  IRequest
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteWorkOrderCommand>
        {
            private readonly IBoqDbContext _context;
            public Handler(IBoqDbContext context)
            {
                _context = context;
            }

            public async Task<MediatR.Unit> Handle(DeleteWorkOrderCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.workOrders.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException("Work Order Log", request.Id);
                }

                _context.workOrders.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return MediatR.Unit.Value;
            }
        }
    }
}