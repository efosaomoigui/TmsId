using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TmsId.Api.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string SiteId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string AssetId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string RegistrationNumber { get; set; }

        public DateTime LastPositionTimestamp { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public double Latitude { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public double Longitute { get; set; }

        public string CurrentAddress { get; set; }
    }
}
