namespace Drone.Core.DomainModels
{
    public class Container
    {
        public Container(
            string name,
            string description,
            string serialNumber,
            int id = 0)
        {
            Id = id;
            Name = name;
            Description = description;
            SerialNumber = serialNumber;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }
    }
}
