using FluentValidation;
using System;

namespace BlueBoard.Application.Common
{
    public abstract class BaseGetQueryValidator<TQuery> : AbstractValidator<TQuery> where TQuery : BaseGetQuery
    {
        protected BaseGetQueryValidator()
        {
            RuleFor(i => i.Id).NotEqual(Guid.Empty);
        }
    }
}
