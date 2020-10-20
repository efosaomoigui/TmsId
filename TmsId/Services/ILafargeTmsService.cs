using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TmsId.Api.Models;
using TmsId.Shared;

namespace TmsId.Api.Services
{
    public interface ILafargeTmsService
    {
        Task<List<TruckViewModel>> GetAllTrucks();
        Task<List<DriverViewModel>> GetAllDrivers();
        Task<double> GetDistanceInKm(FilterCriteriaViewModel filtercriteria);
        Task<PositionViewModel> GetLocationByDriver(FilterCriteriaViewModel filtercriteria);
        Task<PositionViewModel> GetLocationByAssetId(FilterCriteriaViewModel filtercriteria);
    }

    public class LafargeTmsService : ILafargeTmsService 
    {
        private ITmsDbContext _context;

        public LafargeTmsService(ITmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<DriverViewModel>> GetAllDrivers()
        {
            var result = _context.Drivers.ToList();
            return result.Select(s => new DriverViewModel
            {
                Id = s.Id,
                Name = s.Name,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                SiteId = s.SiteId, 
                DriverId = s.DriverId,
                EmployeeNumber = s.EmployeeNumber

            }).ToList();
        }

        public async Task<List<TruckViewModel>> GetAllTrucks()
        {
            var result = _context.Trucks.ToList();
            return result.Select(s => new TruckViewModel
            {
                AssetId = s.AssetId,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                SiteId = s.SiteId,
                CurrentAddress = s.CurrentAddress,
                LastPositionTimestamp = s.LastPositionTimestamp, 
                Id = s.Id,
                Longitute = s.Longitute,
                Latitude = s.Latitude,
                RegistrationNumber = s.RegistrationNumber

            }).ToList();
        }

        public async Task<double> GetDistanceInKm(FilterCriteriaViewModel filtercriteria)
        {
            var Truckresult = _context.Trucks.Where(s => s.AssetId == filtercriteria.AssetId).FirstOrDefault();

            var sCoord = new GeoCoordinate();
            var eCoord = new GeoCoordinate();

            if (Truckresult != null)
            {
                sCoord = new GeoCoordinate(Truckresult.Latitude, filtercriteria.Longitude);
                eCoord = new GeoCoordinate(Truckresult.Longitute, filtercriteria.Latitude);
            }

            sCoord = new GeoCoordinate(0, filtercriteria.Longitude);
            eCoord = new GeoCoordinate(0, filtercriteria.Latitude);

            var kmResult = sCoord.GetDistanceTo(eCoord)/1000;

            return kmResult;

        }

        public async Task<PositionViewModel> GetLocationByAssetId(FilterCriteriaViewModel filtercriteria) 
        {
            if (filtercriteria.AssetId == null)
            {
                throw new Exception("Truck information must be provided");
            }

            var Positionesult = _context.Positions.Where(s => s.AssetId == filtercriteria.AssetId).FirstOrDefault();
            var Truckresult = _context.Trucks.Where(s => s.AssetId == filtercriteria.AssetId).FirstOrDefault();

            if (Positionesult != null)
            {
                var location = new PositionViewModel
                {
                    CreatedAt = Positionesult.CreatedAt,
                    Latitude = Positionesult.Latitude,
                    Longitude = Positionesult.Longitude,
                    CurrentAddress = Truckresult?.CurrentAddress,
                    TimeStamp = (Truckresult != null) ? Truckresult.LastPositionTimestamp : DateTime.Today
                };

                return location;

            }
            return null;
        }

        public async Task<PositionViewModel> GetLocationByDriver(FilterCriteriaViewModel filtercriteria) 
        {
            if (filtercriteria.DriverId == null)
            {
                throw new Exception("Driver information must be provided");
            }

            var Positionesult = _context.Positions.Where(s => s.DriverId == filtercriteria.DriverId).FirstOrDefault();

            if (Positionesult != null)
            {
                var Truckresult = _context.Trucks.Where(s => s.AssetId == Positionesult.AssetId).FirstOrDefault();
                var location = new PositionViewModel
                {
                    CreatedAt = Positionesult.CreatedAt,
                    Latitude = Positionesult.Latitude,
                    Longitude = Positionesult.Longitude,
                    CurrentAddress = Truckresult?.CurrentAddress,
                    TimeStamp = (Truckresult !=null)?Truckresult.LastPositionTimestamp : DateTime.Today
                };

                return location;

            }

            return null;

        }
    }

}
