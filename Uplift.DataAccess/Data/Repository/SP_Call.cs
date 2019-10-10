using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace Uplift.DataAccess.Data.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private string ConnectonString = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectonString = db.Database.GetDbConnection().ConnectionString;
        }
       

        public T ExecuteReturnScaler<T>(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectonString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(ProcedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public void ExecuteWithoutReturn(string ProcedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectonString))
            {
                sqlCon.Open();
                sqlCon.Execute(ProcedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> ReturnList<T>(string ProcedureName, DynamicParameters param = null)
        {
            using(SqlConnection sqlCon = new SqlConnection(ConnectonString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(ProcedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
