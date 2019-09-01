using AutoMapper;
using BlueBoard.Application.Infrastructure;
using BlueBoard.Application.Users.Models;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using BlueBoard.Application.Exceptions;
using BlueBoard.Domain;

namespace BlueBoard.Application.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : BaseHandler<GetCurrentUserQuery, SlimUserModel>
    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserRepository _userRepository;

        public GetCurrentUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<GetCurrentUserQuery, SlimUserModel>> logger, ICurrentUserProvider currentUserProvider) : base(unitOfWork, mapper, logger)
        {
            _currentUserProvider = currentUserProvider;
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<SlimUserModel> Handle(GetCurrentUserQuery request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(_currentUserProvider.UserId);
            if (user == null) throw new NotFoundException(nameof(User), _currentUserProvider.UserId);
            return Mapper.Map<SlimUserModel>(user);
        }
    }
}
