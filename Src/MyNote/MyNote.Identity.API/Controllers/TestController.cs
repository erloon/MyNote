using System;
using System.Threading.Tasks;
using Marten;
using Marten.Events;
using Microsoft.AspNetCore.Mvc;
using MyNote.Identity.Domain.Events.User;
using MyNote.Identity.Domain.Model;

namespace MyNote.Identity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly IDocumentSession _session;
        private IEventStore _store => _session.Events;

        public TestController(IDocumentSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            _session = session;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var myEvent = new UserCreated()
            {
                IsAdministrator = true
            };

            var eventId = Guid.NewGuid();

            try
            {
                _store.Append(eventId, myEvent);
                _session.SaveChanges();
            }
            catch (Exception ex)
            {
              
                throw;
            }
            return new OkResult();
        }
    }
}