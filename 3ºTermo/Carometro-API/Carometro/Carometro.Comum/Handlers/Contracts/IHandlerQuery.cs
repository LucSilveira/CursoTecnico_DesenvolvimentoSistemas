﻿using Carometro.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Comum.Handlers.Contracts
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handle(T command);
    }
}
