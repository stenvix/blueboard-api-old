using AutoMapper;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Participants.Models;
using BlueBoard.Common.Enums;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Queries.SearchParticipants
{
    public class SearchParticipantQueryHandler : BaseHandler<SearchParticipantQuery, IList<ParticipantSearchModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserRepository _userRepository;
        private readonly IParticipantRepository _participantRepository;

        public SearchParticipantQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SearchParticipantQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
            _participantRepository = unitOfWork.GetRepository<IParticipantRepository>();
        }

        protected override async Task<IList<ParticipantSearchModel>> Handle(SearchParticipantQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var users = await _userRepository.SearchAsync(request.Query, _currentUserProvider.UserId);

            var tripParticipants = await _participantRepository.GetForSearchAsync(request.TripId);

            var participants = new List<ParticipantSearchModel>();
            foreach (var user in users)
            {
                var participant = Mapper.Map<ParticipantSearchModel>(user);
                participants.Add(participant);
                var tripParticipant = tripParticipants.FirstOrDefault(i => i.UserId == user.Id);
                participant.Status = tripParticipant?.Status ?? ParticipantStatus.Nonparticipant;
            }

            return participants;
        }
    }
}
