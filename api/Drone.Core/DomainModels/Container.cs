using System;

namespace Drone.Core.DomainModels
{
    public class Container
    {
        public Container(
            string name,
            string description,
            string serialNumber,
            DateTime dateCreated,
            int id = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            SerialNumber = serialNumber;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string SerialNumber { get; private set; }

        public DateTime DateCreated { get; private set; }
    }
}
