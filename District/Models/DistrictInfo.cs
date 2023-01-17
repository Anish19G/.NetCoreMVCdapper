namespace District.Models
{
    public class DistrictInfo
    {
        public int DId { get; set; }
        public string DName { get; set; }

        public int TotalRowCount { get; set; }
    }

    public class DistrictInfoModel
    {
        public List<DistrictInfo> _districtInfos = new List<DistrictInfo>();
        public List<DistrictInfo> DistrictsList
        {
            get { return _districtInfos; }
            set { _districtInfos = value; }
        }
    }
}
