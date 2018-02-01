using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNote.MVC.Application;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;

namespace MyNote.MVC.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IIdentityService _identityService;

        public NotesController(INoteService noteService, IIdentityService identityService)
        {
            _noteService = noteService;
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }
        public async Task<IActionResult> Index(HomePageVM vm)
        {
            if (vm.OrganizationContext == null)
            {
                var organizationContext = await _identityService.GetOrganizationContext();
                vm.OrganizationContext = organizationContext;
                vm.OrganizationContext.AddAvailableProjects();
                vm.OrganizationContext.AddAvailableTeamsList();
            }
            return View(vm);
        }

        public IActionResult CreateNote(HomePageVM vm, Guid noteId)
        {
            Note note = null;
            if (noteId != null && noteId != Guid.Empty) note = _noteService.Get(noteId);

            if (vm.OrganizationContext == null)
            {
                var organizationContext = _identityService.GetOrganizationContext().Result;
                vm.OrganizationContext = organizationContext;
                vm.OrganizationContext.AddAvailableProjects();
                vm.OrganizationContext.AddAvailableTeamsList();
            }

            if (note != null)
            {
                vm.CreateNote = new CreateNote()
                {
                    Category = new MyNote.MVC.Models.VM.Category()
                    {
                        Name = note.Category.Name
                    },
                    Title = note.Title,
                    Content = note.Content,
                    Files = note.Files,
                    Images = note.Images,
                    Name = note.Name,
                    NoteId = note.Id,
                    OrganizationId = note.OrganizationId,
                    OwnerId = note.OwnerId
                };
            }
            return View(vm);
        }

        public IActionResult SaveNote(HomePageVM vm)
        {
            if (vm.OrganizationContext == null)
            {
                var organizationContext = _identityService.GetOrganizationContext().Result;
                vm.OrganizationContext = organizationContext;
                vm.OrganizationContext.AddAvailableProjects();
                vm.OrganizationContext.AddAvailableTeamsList();
            }

            var files = ViewData["Files"] as List<MyNote.MVC.Models.DTO.File>;

            if (files != null)
            {
                vm.CreateNote.Files = new List<Guid>();
                files.ForEach(x => vm.CreateNote.Files.Add(x.Id));
            }

            Note note = null;

            if (vm.CreateNote != null) note = _noteService.CreateNote(vm.CreateNote).Result;

            //TempData["note"] = vm;
            return RedirectToAction("CreateNote", new { vm = vm, noteId = note.Id });
        }

        public void CreateImage(CreateFormFile createImage)
        {
            if (createImage == null) throw new ArgumentNullException(nameof(createImage));

            var image = _noteService.CreateImage(createImage).Result;
            TempData["Image"] = image;
        }

        public async void CreateImages(CreateImages files)
        {
            if (files == null) throw new ArgumentNullException(nameof(files));
            var images = await _noteService.CreateImages(files);
            TempData["Images"] = images;
        }

        public IActionResult CreateFiles(CreateFiles files)
        {
            if (files == null) throw new ArgumentNullException(nameof(files));
            var savedFiles = _noteService.CreateFiles(files).Result;

            var note = TempData["note"] as HomePageVM;
            TempData["Files"] = savedFiles;
            return RedirectToAction("CreateNote", note);
        }


    }
}