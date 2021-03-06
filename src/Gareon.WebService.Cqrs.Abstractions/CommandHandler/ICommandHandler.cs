﻿using Gareon.WebService.Cqrs.Abstractions.Base;
using MediatR;

namespace Gareon.WebService.Cqrs.Abstractions.CommandHandler
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : class, ICommand<TResponse>
    {
        
    }

    public interface IVoidCommandHandler<in TVoidCommand> : IRequestHandler<TVoidCommand>
        where TVoidCommand : class, IVoidCommand
    {
        
    }
}