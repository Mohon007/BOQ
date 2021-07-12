using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class StandardSpecification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public string ProductType { get; set; }
        public double AverageRate { get; set; }
        public double QuantityInPack { get; set; }
        public string ProcurementSource { get; set; }
        public double OpeningBalance { get; set; }
        public string Remarks { get; set; }
    }
}
