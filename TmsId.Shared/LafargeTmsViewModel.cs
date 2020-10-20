using System;
using System.Collections.Generic;
using System.Text;

namespace TmsId.Shared
{
    public class LafargeTmsViewModel
    {

    }

    public class TruckViewModel 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string SiteId { get; set; }
        public string AssetId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime LastPositionTimestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitute { get; set; }
        public string CurrentAddress { get; set; }
    }


    public class DriverViewModel 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string SiteId { get; set; }
        public string DriverId { get; set; }
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }
    }

    public class PositionViewModel 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AgeOfReadingSeconds { get; set; }
        public string AssetId { get; set; }
        public int AltitudeMetres { get; set; }
        public string DriverId { get; set; }
        public int Heading { get; set; }

        public double Latitude { get; set; }
        public int IsAvl { get; set; }
        public int OdometerKilometres { get; set; }

        public double Longitude { get; set; }
        public int Hdop { get; set; }
        public long PositionId { get; set; }
        public int Pdop { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Source { get; set; }
        public int SpeedKilometresPerHour { get; set; }
        public int SpeedLimit { get; set; }
        public int Vdop { get; set; }
        public string CurrentAddress { get; set; }
        public LafargeGenericException Ex { get; set; } 
    }

    public class FilterCriteriaViewModel 
    {
        public string AssetId { get; set; }
        public string DriverId { get; set; }
        public string StaticDistance { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
}
