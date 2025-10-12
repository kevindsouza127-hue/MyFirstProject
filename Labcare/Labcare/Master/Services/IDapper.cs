using Dapper;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Labcare.Master.Services
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
        Task<T> GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
        Task<List<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeOut = 30);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeOut = 30);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
        SqlMapper.GridReader GetMultiple(IDbConnection db, string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeOut = 30);
        Task<SqlMapper.GridReader> GetMultipleAsync(IDbConnection db, string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, int CommandTimeout = 30);
     
    }
}
