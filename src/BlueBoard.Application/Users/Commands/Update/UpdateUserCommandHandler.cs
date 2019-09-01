using AutoMapper;
using BlueBoard.Application.Exceptions;
using BlueBoard.Domain;
using BlueBoard.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : BaseHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BaseHandler<UpdateUserCommand, Guid>> logger) : base(unitOfWork, mapper, logger)
        {
            _userRepository = unitOfWork.GetRepository<IUserRepository>();
        }

        protected override async Task<Guid> Handle(UpdateUserCommand request, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetActiveAsync(request.Id);
            if (entity == null) throw new NotFoundException(nameof(User), request.Id);

            Mapper.Map(request, entity);

            await _userRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();

            return request.Id;
        }
    }
}
