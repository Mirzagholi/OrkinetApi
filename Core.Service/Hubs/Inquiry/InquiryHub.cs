using Core.Service.Hubs.Inquiry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Core.Service.Hubs
{
    [Authorize]
    public class InquiryHub : Hub<IInquiryClient>
    {
        #region Config

        //private static readonly ConcurrentDictionary<string, InquiryHubUser> Users = new ConcurrentDictionary<string, InquiryHubUser>();

        //public override async Task OnConnectedAsync()
        //{
        //    ConnectUserToHub();
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    var userName = Context.User.Identity.Name;
        //    var connectionId = Context.ConnectionId;

        //    InquiryHubUser user;
        //    Users.TryGetValue(userName, out user);
        //    if (user != null)
        //    {
        //        lock (user.ConnectionIds)
        //        {
        //            user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

        //            if (!user.ConnectionIds.Any())
        //            {
        //                InquiryHubUser removedUser;
        //                Users.TryRemove(userName, out removedUser);
        //            }
        //        }
        //    }

        //    await base.OnDisconnectedAsync(exception);
        //}

        //private void ConnectUserToHub()
        //{
        //    var userId = HttpContextExtensions.GetUserId().Value;
        //    var role = HttpContextExtensions.GetRole();
        //    var providerId = HttpContextExtensions.GetProviderId();
        //    var connectionId = Context.ConnectionId;

        //    var user = Users.GetOrAdd($"InquiryUser-{userId}",
        //        _ => new InquiryHubUser
        //        {
        //            UserId = userId,
        //            ProviderId = providerId,
        //            Role = role,
        //            ConnectionIds = new HashSet<string>()
        //        });
        //    lock (user.ConnectionIds)
        //    {
        //        user.ConnectionIds.Add(connectionId);
        //    }
        //}

        //private List<string> GetAllConnectionIdes(string role)
        //{
        //    var response = new List<string>();
        //    var UserConnectionIds = Users.Where(z => z.Value.Role == ConstantRoles.Admin).Select(z => z.Value.ConnectionIds.ToList()).ToList();

        //    if (UserConnectionIds.Count == 0)
        //        return response;

        //    foreach(var connectionId in UserConnectionIds)
        //        response.AddRange(connectionId);

        //    return response;
        //}

        #endregion

        //public Task NotifyToUser()
        //{
        //    //this.Clients.Client(this.Context.ConnectionId).SendAsync("method", "message");
        //    var userId = HttpContextExtensions.GetUserId().Value;

        //    return Clients.All.SendAsync("NotifyToUser");
        //}

        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.User(user).ReceiveMessage(user, message);
        //}

        //public Task SendMessageToCaller(string user, string message)
        //{
        //    return Clients.Caller.ReceiveMessage(user, message);
        //}

        //public Task NotifyToAdmin()
        //{
        //    var connectionIds = GetAllConnectionIdes(ConstantRoles.Provider);
        //    return Clients.Clients(connectionIds).SendAsync("NotifyToAdminClient");
        //}
    }
}
