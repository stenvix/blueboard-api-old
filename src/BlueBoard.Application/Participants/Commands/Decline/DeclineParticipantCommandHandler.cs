using AutoMapper;
using BlueBoard.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Commands.Decline
{
    public class DeclineParticipantCommandHandler : BaseHandler<DeclineParticipantCommand, Unit>
    {
        public DeclineParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<DeclineParticipantCommand, Unit>> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override Task<Unit> Handle(DeclineParticipantCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
