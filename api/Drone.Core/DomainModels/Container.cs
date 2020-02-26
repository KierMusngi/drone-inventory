using System;

namespace Drone.Core.DomainModels
{
    public class Container
    {
        public Container(
            string name,
            string description,
            string serialNumber,
            int itemCount,
            int boxCount,
            string placement,
            DateTime expirationDate,
            DateTime manufacturingDate,
            DateTime dateCreated,
            int id = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            SerialNumber = serialNumber;
            ItemCount = itemCount;
            BoxCount = boxCount;
            Placement = placement;
            ExpirationDate = expirationDate;
            ManufacturingDate = manufacturingDate;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string SerialNumber { get; private set; }

        public int ItemCount { get; private set; }

        public int BoxCount { get; private set; }

        public string Placement { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public DateTime ManufacturingDate { get; private set; }

        public DateTime DateCreated { get; private set; }
    }
}
