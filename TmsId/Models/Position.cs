using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TmsId.Api.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AgeOfReadingSeconds { get; set; }
        public string AssetId { get; set; }
        public int AltitudeMetres { get; set; }
        public string DriverId { get; set; }
        public int Heading { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public double Latitude { get; set; }
        public int IsAvl { get; set; }
        public int OdometerKilometres { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public double Longitude { get; set; }
        public int Hdop { get; set; }
        public long PositionId { get; set; }
        public int Pdop { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Source { get; set; }
        public int SpeedKilometresPerHour { get; set; }
        public int SpeedLimit { get; set; }
        public Nullable<int> Vdop { get; set; }
    }
}
