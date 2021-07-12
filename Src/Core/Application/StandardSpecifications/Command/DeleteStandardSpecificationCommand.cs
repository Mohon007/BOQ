using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StandardSpecifications.Command
{
    public class DeleteStandardSpecificationCommand :  IRequest
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteStandardSpecificationCommand>
        {
            private readonly IBoqDbContext _context;
            public Handler(IBoqDbContext context)
            {
                _context = context;
            }

            public async Task<MediatR.Unit> Handle(DeleteStandardSpecificationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.standardSpecifications.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException("Standard Specification Log", request.Id);
                }

                _context.standardSpecifications.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return MediatR.Unit.Value;
            }
        }
    }
}