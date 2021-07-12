using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.StandardSpecifications.Model;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StandardSpecifications.Queries
{
    public class GetStandardSpecificationDetailsQuery : IRequest<StandardSpecificationModel>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetStandardSpecificationDetailsQuery, StandardSpecificationModel>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<StandardSpecificationModel> Handle(GetStandardSpecificationDetailsQuery request, CancellationToken cancellationToken)
            {
                if (request.Id == 0)
                {
                    return new StandardSpecificationModel();
                }
                var entity = await _context.standardSpecifications.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException("Standard Specification Log", request.Id);
                }
                return _mapper.Map<StandardSpecificationModel>(entity);
            }
        }
    }
}

