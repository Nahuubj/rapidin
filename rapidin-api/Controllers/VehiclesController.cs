using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rapidin_api.Data;

namespace rapidin_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehiclesController(AppDbContext context) => _context = context;


        [HttpGet("get-vehicle")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicleDetails = await (
                from vehicle in _context.vehicle
                join enterprise in _context.enterprise on vehicle.id_enterprise equals enterprise.id
                join catalog in _context.catalog on vehicle.id_catalog equals catalog.id
                where vehicle.id == id
                select new
                {
                    Vehicle = vehicle,
                    Enterprise = enterprise,
                    Catalog = catalog
                }
            ).FirstOrDefaultAsync();

            if (vehicleDetails == null)
            {
                return NotFound("Vehicle not found.");
            }

            var mediaLinks = await (
                from media in _context.media
                where media.id_catalog == vehicleDetails.Catalog.id
                select media.link
            ).ToListAsync();

            var result = new
            {
                VehicleId = vehicleDetails.Vehicle.id,
                Color = vehicleDetails.Vehicle.color,
                State = vehicleDetails.Vehicle.state,
                Disponibility = vehicleDetails.Vehicle.disponibility,
                Mileage = vehicleDetails.Vehicle.mileage,
                CC = vehicleDetails.Vehicle.cc,
                EngineHP = vehicleDetails.Vehicle.engineHP,
                Price = vehicleDetails.Vehicle.price,
                Likes = vehicleDetails.Vehicle.likes,
                EnterpriseName = vehicleDetails.Enterprise.name,
                Brand = vehicleDetails.Catalog.brand,
                Model = vehicleDetails.Catalog.model,
                Description = vehicleDetails.Catalog.description,
                MediaLinks = mediaLinks
            };

            return Ok(result);
        }

        [HttpGet("get-enterprise-vehicles")]
        public async Task<IActionResult> GetEnterpriseVehicles(int id)
        {
            var vehicles = await (
                from vehicle in _context.vehicle
                join catalog in _context.catalog on vehicle.id_catalog equals catalog.id
                where vehicle.id_enterprise == id
                select new
                {
                    VehicleId = vehicle.id,
                    Brand = catalog.brand,
                    Model = catalog.model,
                    Price = vehicle.price,
                    Disponibility = vehicle.disponibility,
                    Likes = vehicle.likes,
                    Links = (
                        from media in _context.media
                        where media.id_catalog == catalog.id
                        select media.link
                    ).ToList()
                }
            ).ToListAsync();

            if (!vehicles.Any())
            {
                return NotFound("No vehicles found for the specified enterprise.");
            }

            return Ok(vehicles);
        }

    }
}
