using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Drone.API.Hubs
{
    public class ScannerHub : Hub
    {
        public async Task Send(
            string name, 
            string description, 
            string serialNumber, 
            int itemCount, 
            int boxCount,
            string placement,
            string expirationDate, 
            string manufacturingDate)
        {
            await Clients.All.SendAsync(
                "receive",
                name, 
                description, 
                serialNumber,
                itemCount,
                boxCount,
                placement,
                expirationDate,
                manufacturingDate);
        }
    }
}
