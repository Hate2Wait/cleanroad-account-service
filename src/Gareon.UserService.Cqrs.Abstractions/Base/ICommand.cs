using MediatR;

namespace Gareon.UserService.Cqrs.Abstractions.Base
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        
    }
}