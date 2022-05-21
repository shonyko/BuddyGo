using Microsoft.AspNetCore.SignalR;

namespace BuddyGo.Hubs {
    public class NotificationHub : Hub {
        public async Task SendNotification(string announcement) {
            await Clients.All.SendAsync("ReceiveNotification", announcement);
        }
    }
}
