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
            string expirationDate, 
            string manufacturingDate)
        {
            await Clients.All.SendAsync(
                "receive",
                name, 
                description, 
                serialNumber,
                itemCount,
                expirationDate,
                manufacturingDate);
        }
    }
}
