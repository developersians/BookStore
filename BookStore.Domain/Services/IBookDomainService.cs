using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface IBookDomainService
    {
        Task<bool> IsNameUnique(string name);
    }
}
