using BlueBoard.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using BlueBoard.Persistence.Repositories;

namespace BlueBoard.Application
{
    public abstract class BaseHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        #region Fields

        private IUnitOfWork _unitOfWork;
        protected ILogger<BaseHandler<TRequest, TResult>> Logger;

        #endregion

        protected BaseHandler(IUnitOfWork unitOfWork, ILogger<BaseHandler<TRequest, TResult>> logger)
        {
            _unitOfWork = unitOfWork;
            Logger = logger;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request), "Request can't be null");
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var result = await Handle(request, _unitOfWork, cancellationToken);
                    _unitOfWork.CommitTransaction(transaction);
                    return result;
                }
                catch (Exception e)
                {
                    Logger.LogError(e, "An error occurred while completing the request");
                    _unitOfWork.RollbackTransaction(transaction);
                    throw;
                }
            }
        }

        protected abstract Task<TResult> Handle(TRequest request, IUnitOfWork unitOfWork, CancellationToken cancellationToken);
    }
}
