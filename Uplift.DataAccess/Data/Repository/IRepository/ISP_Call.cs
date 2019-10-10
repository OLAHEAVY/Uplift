using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        IEnumerable<T> ReturnList<T>(string ProcedureName, DynamicParameters param = null);

        void ExecuteWithoutReturn(string ProcedureName, DynamicParameters param = null);

        T ExecuteReturnScaler<T>(string ProcedureName, DynamicParameters param = null);
    }
}
