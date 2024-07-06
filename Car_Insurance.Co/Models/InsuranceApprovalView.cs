namespace Car_Insurance.Co.Models
{
    public class InsuranceApprovalView
    {
        public OrderDetail? orderstatus { get; set; }
        public IEnumerable<UserCarsDetail>? cardetail { get; set; }
    }
}
