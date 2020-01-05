using Drone.API.Models.Views;
using Drone.Core.DomainModels;

namespace Drone.API.Helpers
{
    public static class ViewModelMapper
    {
        public static ContainerView ToViewModel(this Container container)
        {
            return new ContainerView()
            {
                Id = container.Id,
                Name = container.Name,
                Description = container.Description,
                SerialNumber = container.SerialNumber
            };
        }
    }
}
