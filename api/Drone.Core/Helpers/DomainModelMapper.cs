using Drone.Core.DomainModels;
using Drone.DataAccess.Entities;

namespace Drone.Core.Helpers
{
    public static class DomainModelMapper
    {
        public static Container ToDomainModel(this ContainerEntity containerEntity)
        {
            return new Container(
                name: containerEntity.Name,
                description: containerEntity.Description,
                serialNumber: containerEntity.SerialNumber,
                id: containerEntity.Id);
        }
    }
}
