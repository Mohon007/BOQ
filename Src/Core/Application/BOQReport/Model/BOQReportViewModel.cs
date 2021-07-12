
namespace Application.BOQReport.Model
{
    public class BOQReportViewModel
    {
    }
    public class BOQReportModel
    {
        public int SlNo { get; set; }
        public string OrderNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double OrderQty { get; set; }
        public string MatCode { get; set; }
        public string MatName { get; set; }
        public string MatUnit { get; set; }
        public string Ups { get; set; }
        public double PaperQty { get; set; }
        public double TotalPack { get; set; }
        public decimal ApproxUnitRate { get; set; }
        public decimal TotalAmountIncludeCarrying { get; set; }
    }
}