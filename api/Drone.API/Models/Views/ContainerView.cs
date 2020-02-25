namespace Drone.API.Models.Views
{
    public class ContainerView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public int ItemCount { get; set; }

        public string ExpirationDate { get; set; }

        public string ManufacturingDate { get; set; }

        public string DateCreated { get; set; }

        public int BoxCount { get; set; }
    }
}
