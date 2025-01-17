using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC.Hubs;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        
        private readonly IUserDBService _service;

        private readonly IHubContext<MessageHub> _hub;

        public InvitationsController(IUserDBService service, IHubContext<MessageHub> messageHub)
        {
            _service = service;
            _hub = messageHub;
        }

        /**
         * Adds a new contact to the user.
         */
        [HttpPost]
        public async Task<IActionResult> PostInv([FromBody] TraInv details)
        {
            // Gets the user from the service and makes sure he exists and the friend isn't already in his friend list.
            var user = await _service.Get(details.To);
            var friend = await _service.GetContact(user.Id, details.From);
            if (user == null || friend != null)
                return NotFound();
            // Adds the contact to the user contacts.
            var friendContact = new Contact
            {
                Id = details.From, Name = details.From, Server = details.Server
            };
            await _service.AddContact(user.Id, details.From, details.From, details.Server);
            // If the user is connected it will update him that a new user contact has been added.
            await _hub.Clients.Group(user.Id).SendAsync("FriendAdded");
            Uri uri = new Uri($"https://localhost:7225/api/Contacts/{friendContact.Id}");
            return Created(uri, friendContact);
        }
    }
}
