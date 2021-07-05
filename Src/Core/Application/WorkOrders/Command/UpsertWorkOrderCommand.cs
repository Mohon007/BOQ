using Application.Common.Interfaces;
using Application.WorkOrders.Model;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WorkOrders.Command
{
    public class UpsertWorkOrderCommand : WorkOrderModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertWorkOrderCommand, int>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<int> Handle(UpsertWorkOrderCommand request, CancellationToken cancellationToken)
            {
                WorkOrder entity;
                if (request.Id == 0)
                {
                    entity = new WorkOrder();
                    _context.workOrders.Add(entity);
                }
                else
                {
                    entity = await _context.workOrders.FindAsync(request.Id);
                }
                entity = _mapper.Map((WorkOrderModel)request, entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}
