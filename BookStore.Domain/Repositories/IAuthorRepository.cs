﻿using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
    public interface IAuthorRepository : IQueryRepository<Author>, ICommandRepository<Author>
    {
    }
}
