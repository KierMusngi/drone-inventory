using System;
using System.ComponentModel.DataAnnotations;

namespace Drone.DataAccess.Entities
{
    public class ContainerEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
