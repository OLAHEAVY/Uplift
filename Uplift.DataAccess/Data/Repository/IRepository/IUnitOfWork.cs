using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IFrequencyRepository Frequency { get; }

        IServiceRepository Service { get; }

        IOrderDetailsRepository OrderDetails { get; }

        IOrderHeaderRepository OrderHeader { get; }

        IUserRepository User { get; }

        ISP_Call SP_Call { get; }

        void Save();
    }
}
