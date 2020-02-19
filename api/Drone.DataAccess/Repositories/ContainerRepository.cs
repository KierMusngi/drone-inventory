using Drone.DataAccess.Entities;
using Drone.DataAccess.Repositories.Interfaces;
using System.Linq;

namespace Drone.DataAccess.Repositories
{
    public class ContainerRepository: Repository<ContainerEntity>, IContainerRepository
    {
        private readonly DroneContext _context;

        public ContainerRepository(DroneContext context) : base(context)
        {
            _context = context;
        }

        public int GetContainerCountBySerialNumber(string serialNumber)
        {
            return _context.Containers
                .Where(container => container.SerialNumber == serialNumber)
                .ToList().Count();
        }
    }
}
