using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Repositories
{
    public interface IUnitOfWork //: IDisposable
    {
        public bool HasChanges { get; }

        Task<int> Commit(CancellationToken cancellationToken);

        Task Rollback();
    }
}
