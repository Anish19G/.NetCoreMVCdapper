using Dapper;
using District.Infrastructure.IRepository;
using District.Models;


namespace District.Infrastructure.Repository
{
    public class Disrict : IDistrict
    {
        private readonly IDapperServices _dapper;

        public Disrict(IDapperServices dapper)
        {
            _dapper = dapper;
        }

        public DistrictInfo AddDistrict(DistrictInfo districtInfo)
        {
            DistrictInfo model = new DistrictInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@DId", districtInfo.DId);
                dbPara.Add("DName", districtInfo.DName);

                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<DistrictInfo>("DistrictAddEdit", dbPara, commandType: System.Data.CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public DistrictInfo DeleteDistrict(DistrictInfo infomodel)
        {
            DistrictInfo model = new DistrictInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("@DId", infomodel.DId);
                
                model.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<DistrictInfo>("DistrictDelete", dbPara, commandType: System.Data.CommandType.StoredProcedure)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public DistrictInfo GetDistrictById(int id)
        {
            var query = @"Select * from Distric where DId = @DId";
            DistrictInfo districtInfo = new DistrictInfo();
            try
            {
                var dbPara = new DynamicParameters();
                dbPara.Add("DId", id);
                districtInfo = Task.FromResult(_dapper.Get<DistrictInfo>(query, dbPara, commandType: System.Data.CommandType.Text)).Result;
            }
            catch(Exception)
            {
                throw;
            }
            return districtInfo;
        }

        public List<DistrictInfo> GetDistrictData()
        {
            var query = @"Select * from District";
            List<DistrictInfo> districtInfos = new List<DistrictInfo>();
            try
            {
                districtInfos = Task.FromResult(_dapper.GetAll<DistrictInfo>(query, null, commandType: System.Data.CommandType.Text)).Result;
            }
            catch (Exception)
            {
                throw;
            }
            return districtInfos;
        }

        public DistrictInfo UpdateDistict(DistrictInfo districtInfo)
        {
            DistrictInfo model = new DistrictInfo();
            //try
            //{
            //    var dbPara = new DynamicParameters();
            //    dbPara.Add("@DId", districtInfo.DId);
            //    dbPara.Add("DName", districtInfo.DName);

            //    districtInfo.TotalRowCount = Task.FromResult(_dapper.ExecuteScaler<DistrictInfo>("DistrictAddEdit", dbPara, commandType: System.Data.CommandType.StoredProcedure)).Result;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return model;
        }
    }
}
