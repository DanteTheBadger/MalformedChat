using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs;
public class ChatHub : Hub
{
    public async Task Join(string username)
    {

    }
    public async Task JoinRoom(string roomName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync($"{Context.User.Identity.Name} joined.");
    }
    public Task LeaveRoom(string roomName)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
    }
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}