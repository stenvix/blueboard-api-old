using AutoMapper;
using BlueBoard.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Commands.Approve
{
    public class ApproveParticipantCommandHandler : BaseHandler<ApproveParticipantCommand, Unit>
    {
        public ApproveParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<ApproveParticipantCommand, Unit>> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override Task<Unit> Handle(ApproveParticipantCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
