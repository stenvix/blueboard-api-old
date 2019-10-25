using AutoMapper;
using BlueBoard.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Commands.Request
{
    public class RequestParticipantCommandHandler : BaseHandler<RequestParticipantCommand, Unit>
    {
        public RequestParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<RequestParticipantCommand, Unit>> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override Task<Unit> Handle(RequestParticipantCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
