using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.WorkOrders.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WorkOrders.Queries
{
    public  class GetWorkOrderDetailQuery : IRequest<WorkOrderModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetWorkOrderDetailQuery, WorkOrderModel>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<WorkOrderModel> Handle(GetWorkOrderDetailQuery request, CancellationToken cancellationToken)
            {
                if (request.Id == 0)
                {
                    return new WorkOrderModel();
                }
                var entity = await _context.workOrders.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException("Work Order Log", request.Id);
                }
                return _mapper.Map<WorkOrderModel>(entity);
            }
        }
    }
}
