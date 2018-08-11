using System.Threading;
using System.Threading.Tasks;
using CleanRoad.UserService.Cqrs.Abstractions.Base;

namespace CleanRoad.UserService.Cqrs.Abstractions.Bus
{
    public interface ICommandBus
    {
        Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken ctx = default) where TCommand : class, ICommand<TResponse>;

        Task SendAsync<TVoidCommand>(TVoidCommand command, CancellationToken ctx = default) where TVoidCommand : class, IVoidCommand;
    }
}