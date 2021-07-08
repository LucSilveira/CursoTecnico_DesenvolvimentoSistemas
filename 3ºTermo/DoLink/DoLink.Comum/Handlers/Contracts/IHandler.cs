using DoLink.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Comum.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
