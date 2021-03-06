using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class WorkOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Specification { get; set; }
        public string WorkOrderno { get; set; }
        public DateTime CreatedDate { get; set; }
        public string MatName { get; set; }
        public string MatUnit { get; set; }
        public double UPS { get; set; }
        public double QtyPersheet { get; set; }
        public double SheetInReem { get; set; }
        public double RimPrice { get; set; }
    }
}
