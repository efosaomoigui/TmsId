using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TmsId.Api.Models
{
    public class Driver
    {

        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string SiteId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string DriverId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public int EmployeeNumber { get; set; }
    }
}
