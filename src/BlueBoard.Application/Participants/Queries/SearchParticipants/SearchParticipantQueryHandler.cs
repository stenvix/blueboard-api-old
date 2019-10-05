using AutoMapper;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Participants.Queries.SearchParticipants
{
    public class SearchParticipantQueryHandler : BaseHandler<SearchParticipantQuery, IList<SlimUserModel>>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserRepository _userRepository;

        public SearchParticipantQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SearchParticipantQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<IList<SlimUserModel>> Handle(SearchParticipantQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var users = await _userRepository.SearchAsync(request.Query, _currentUserProvider.UserId);
            return Mapper.Map<IList<SlimUserModel>>(users);
        }
    }
}
