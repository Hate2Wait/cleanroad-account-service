using MediatR;

namespace Gareon.WebService.Cqrs.Abstractions.Base
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
        
    }
}