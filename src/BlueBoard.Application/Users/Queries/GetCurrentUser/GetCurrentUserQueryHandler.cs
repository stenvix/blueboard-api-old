using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : BaseHandler<GetCurrentUserQuery, UserModel>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserRepository _userRepository;

        public GetCurrentUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetCurrentUserQueryHandler> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<UserModel> Handle(GetCurrentUserQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetActiveAsync(_currentUserProvider.UserId);
            if (user == null) throw new NotFoundException(nameof(User), _currentUserProvider.UserId);
            return Mapper.Map<UserModel>(user);
        }
    }
}
