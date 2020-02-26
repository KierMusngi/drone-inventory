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
                itemCount: containerEntity.ItemCount,
                boxCount: containerEntity.BoxCount,
                placement: containerEntity.Placement,
                expirationDate: containerEntity.ExpirationDate,
                manufacturingDate: containerEntity.ManufacturingDate,
                dateCreated: containerEntity.DateCreated,
                id: containerEntity.Id);
        }
    }
}
