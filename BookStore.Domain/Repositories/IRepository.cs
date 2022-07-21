﻿using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
    public interface IRepository<T> : IQueryRepository<T>, ICommandRepository<T> where T : EntityBase, IAggregateRoot
    {
    }
}
