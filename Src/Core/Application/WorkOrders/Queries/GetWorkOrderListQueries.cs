using Application.Common.Interfaces;
using Application.WorkOrders.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WorkOrders.Queries
{
    public class GetWorkOrderListQueries : IRequest<WorkOrderListModel>
    {
        public class Handler : IRequestHandler<GetWorkOrderListQueries, WorkOrderListModel>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<WorkOrderListModel> Handle(GetWorkOrderListQueries request, CancellationToken cancellationToken)
            {
                var query = await _context.workOrders
                      .ProjectTo<WorkOrderModel>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
                WorkOrderListModel entity = new WorkOrderListModel
                {
                    WorkOrders = query
                };

                return entity;
            }
        }

    }
}
