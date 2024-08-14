using IronDomeSim.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using static IronDomeSim.Data.Services.Calculations;

namespace IronDomeSim.Socket
{
    public class SocketHub : Hub
    {
        public async Task LaunchMissile(string model, double src_lat, double src_lng, double dst_lat, double dst_lng)
        {
            Console.WriteLine("נכנס");
            double distance = CalculateDistance(src_lat, src_lng, dst_lat, dst_lng);
            Weapon weapon = JsonConvert.DeserializeObject<Weapon>(model)!;
            double seconds = GetResponseTime(distance, weapon.Speed);
            await Clients.Others.SendAsync("Radar", model, seconds, src_lat, src_lng, dst_lat, dst_lng);
        }
    }
}

