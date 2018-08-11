using System.Threading;
using System.Threading.Tasks;
using CleanRoad.UserService.Cqrs.Abstractions.Base;
using CleanRoad.UserService.Cqrs.Abstractions.Bus;
using MediatR;

namespace CleanRoad.UserService.Cqrs.Bus
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator mediator;

        public CommandBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken ctx = default) where TCommand : class, ICommand<TResponse>
        {
            return await this.mediator.Send(command, ctx);
        }

        public async Task SendAsync<TVoidCommand>(TVoidCommand command, CancellationToken ctx = default) where TVoidCommand : class, IVoidCommand
        {
            await this.mediator.Send(command, ctx);
        }
    }
}