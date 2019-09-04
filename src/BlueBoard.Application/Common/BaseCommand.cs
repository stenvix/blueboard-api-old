using MediatR;
using Newtonsoft.Json;

namespace BlueBoard.Application.Common
{
    public abstract class BaseCommand<T> : IRequest<T>
    {
        [JsonIgnore]
        public string RuleSet { get; set; } = "default";
    }
}
