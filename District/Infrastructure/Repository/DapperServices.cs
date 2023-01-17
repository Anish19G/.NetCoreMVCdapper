using Dapper;
using District.Infrastructure.IRepository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace District.Infrastructure.Repository
{
    public class DapperServices : IDapperServices
    {
        private readonly IConfiguration _config;
        private string ConnectionString = "DefaultConnection";

        public DapperServices(IConfiguration config)
        {
            _config = config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteScaler<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Execute(sp, parms, commandType:commandType);
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }
    }
}
