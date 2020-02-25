﻿using Drone.API.Models.Views;
using Drone.Core.DomainModels;

namespace Drone.API.Helpers
{
    public static class ViewModelMapper
    {
        public static ContainerView ToViewModel(this Container container, int containerQuantity)
        {
            return new ContainerView()
            {
                Id = container.Id,
                Name = container.Name,
                Description = container.Description,
                SerialNumber = container.SerialNumber,
                ItemCount = container.ItemCount,
                ExpirationDate = container.ExpirationDate.ToString("dd MMMM yyyy"),
                ManufacturingDate = container.ManufacturingDate.ToString("dd MMMM yyyy"),
                DateCreated = container.DateCreated.ToString("dddd, dd MMMM yyyy hh:mm tt"),
                BoxCount = containerQuantity
            };
        }
    }
}
