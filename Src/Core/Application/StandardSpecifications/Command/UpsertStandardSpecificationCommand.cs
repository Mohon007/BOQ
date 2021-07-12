using Application.Common.Interfaces;
using Application.StandardSpecifications.Model;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StandardSpecifications.Command
{
    public class UpsertStandardSpecificationCommand : StandardSpecificationModel, IRequest<int>
    {
        public class Handler : IRequestHandler<UpsertStandardSpecificationCommand, int>
        {
            private readonly IBoqDbContext _context;
            private readonly IMapper _mapper;
            public Handler(IBoqDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }

            public async Task<int> Handle(UpsertStandardSpecificationCommand request, CancellationToken cancellationToken)
            {
                StandardSpecification entity;
                if (request.Id == 0)
                {
                    entity = new StandardSpecification();
                    _context.standardSpecifications.Add(entity);
                }
                else
                {
                    entity = await _context.standardSpecifications.FindAsync(request.Id);
                }
                entity = _mapper.Map((StandardSpecificationModel)request, entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}