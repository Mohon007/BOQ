using Application.Common.Interfaces;
using Application.StandardSpecifications.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StandardSpecifications.Queries
{
    public class GetStandardSpecificationListQuries : IRequest<StandardSpecificationListModel>
    {
        public class Handler : IRequestHandler<GetStandardSpecificationListQuries, StandardSpecificationListModel>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<StandardSpecificationListModel> Handle(GetStandardSpecificationListQuries request, CancellationToken cancellationToken)
            {
                var query = await _context.standardSpecifications
                      .ProjectTo<StandardSpecificationModel>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
                StandardSpecificationListModel entity = new StandardSpecificationListModel
                {
                    ListModel = query
                };

                return entity;
            }
        }

    }
}
