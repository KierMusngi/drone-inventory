using Drone.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drone.DataAccess
{
    public class DroneContext : DbContext
    {
        public DroneContext(DbContextOptions<DroneContext> options)
            : base(options) { }

        public DbSet<ContainerEntity> Containers { get; set; }
    }
}
