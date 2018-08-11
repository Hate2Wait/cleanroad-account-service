using MediatR;

namespace CleanRoad.UserService.Cqrs.Abstractions.Base
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        
    }
}