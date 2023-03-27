using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStore.Domain.Repositories.Internal
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
