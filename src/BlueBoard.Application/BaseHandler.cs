using BlueBoard.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBoard.Application
{
    public abstract class BaseHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        #region Fields

        protected readonly BlueBoardContext Context;
        protected ILogger<BaseHandler<TRequest, TResult>> Logger;

        #endregion

        protected BaseHandler(BlueBoardContext context, ILogger<BaseHandler<TRequest, TResult>> logger)
        {
            Context = context;
            Logger = logger;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request), "Request can't be null");
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var result = await Handle(request, Context, cancellationToken);
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    Logger.LogError(e, "An error occurred while completing the request");
                    transaction.Rollback();
                    throw;
                }
            }
        }

        protected abstract Task<TResult> Handle(TRequest request, BlueBoardContext context, CancellationToken cancellationToken);
    }
}
