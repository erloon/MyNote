using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyNote.Notes.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Notes")]
    public class NotesController : Controller
    {
    }
}