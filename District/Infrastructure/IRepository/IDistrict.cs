using District.Models;

namespace District.Infrastructure.IRepository
{
    public interface IDistrict
    {
        List<DistrictInfo> GetDistrictData();

        DistrictInfo GetDistrictById(int id);
        DistrictInfo AddDistrict(DistrictInfo districtInfo);
        DistrictInfo UpdateDistict(DistrictInfo districtInfo);
        DistrictInfo DeleteDistrict(DistrictInfo infomodel);
        DistrictInfoModel GetDistrictById();
    }
}
