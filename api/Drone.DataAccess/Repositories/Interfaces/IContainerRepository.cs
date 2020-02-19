using Drone.DataAccess.Entities;
using System.Threading.Tasks;

namespace Drone.DataAccess.Repositories.Interfaces
{
    public interface IContainerRepository : IRepository<ContainerEntity>
    {
        int GetContainerCountBySerialNumber(string serialNumber);
    }
}
