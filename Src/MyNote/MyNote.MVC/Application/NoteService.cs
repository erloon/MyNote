using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyNote.MVC.Infrastructure;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;
using RestSharp;
using RestSharp.Extensions;
using File = MyNote.MVC.Models.DTO.File;

namespace MyNote.MVC.Application
{
    public class NoteService : BaseService, INoteService
    {
        private readonly IIdentityService _identityService;

        public NoteService(string clientUrl,
                            IStoreService storeService,
                            IIdentityService identityService)
            : base(clientUrl, storeService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }
        public async Task<Image> CreateImage(CreateFormFile fileImage)
        {
            if (fileImage == null) throw new ArgumentNullException(nameof(fileImage));


            var organizationContext = _identityService.GetOrganizationContext().Result;

            Image image = null;
            CreateImage CreateImage = new CreateImage()
            {
                Content = fileImage.File.OpenReadStream().ReadAsBytes(),
                Name = fileImage.Name,
                Type = fileImage.File.ContentType,
                OrganizationId = organizationContext.OrganizationId,
            };

            if (CreateImage != null)
            {
                var body = Serialize(CreateImage);
                image = PerformRequestWithCookie<Image>("api/Notes/CreateImage", Method.POST, body).Result;
            }

            return image;
        }

        public async Task<List<Image>> CreateImages(CreateImages createImages)
        {
            if (createImages == null) throw new ArgumentNullException(nameof(createImages));
            List<Image> imagesList = new List<Image>();

            foreach (var image in createImages.Images)
            {
                var result = await CreateImage(new CreateFormFile()
                {
                    Name = image.FileName.Split('.')[0],
                    File = image
                });

                if (result != null) imagesList.Add(result);
            }

            return imagesList;
        }

        public async Task<File> CreateFile(CreateFormFile createFormFile)
        {
            if (createFormFile == null) throw new ArgumentNullException(nameof(createFormFile));

            var organizationContext = await _identityService.GetOrganizationContext();

            File file = null;
            Models.VM.CreateFile createFile = new CreateFile()
            {
                Content = createFormFile.File.OpenReadStream().ReadAsBytes(),
                FileType = FileType.PDF,
                Name = createFormFile.File.FileName.Split('.')[0],
                OrganizationId = organizationContext.OrganizationId,
                Size = createFormFile.File.Length
            };

            if (createFile != null)
            {
                var body = Serialize(createFile);
                file = await PerformRequestWithCookie<File>("api/Notes/CreateFile", Method.POST, body);
            }

            return file;
        }

        public async Task<List<File>> CreateFiles(CreateFiles createFiles)
        {
            if (createFiles == null) throw new ArgumentNullException(nameof(createFiles));

            List<File> fileList = new List<File>();
            var organizationContext = _identityService.GetOrganizationContext().Result;


            foreach (var file in createFiles.Files)
            {
                Models.VM.CreateFile createFile = new CreateFile()
                {
                    Content = file.OpenReadStream().ReadAsBytes(),
                    FileType = FileType.PDF,
                    Name = file.FileName.Split('.')[0],
                    OrganizationId = organizationContext.OrganizationId,
                    Size = file.Length
                };
                File newFile = null;

                if (createFile != null)
                {
                    var body = Serialize(createFile);
                    newFile = PerformRequestWithCookie<File>("api/Notes/CreateFile", Method.POST, body).Result;
                }
                if (newFile != null) fileList.Add(newFile);
            }

            return fileList;
        }

        public async Task<Note> CreateNote(CreateNote createNote)
        {
            if (createNote == null) throw new ArgumentNullException(nameof(createNote));
            var organizationContext = await _identityService.GetOrganizationContext();
            createNote.OrganizationId = organizationContext.OrganizationId;
            createNote.OwnerId = organizationContext.UserId;

            var body = Serialize(createNote);
            var note = await PerformRequestWithCookie<Note>("api/Notes/Create", Method.POST, body);
            return note;
        }

        public Note Get(Guid noteId)
        {
            var note = PerformRequestWithCookie<Note>($"/api/Notes/Get/{noteId}", Method.GET).Result;
            return note;
        }
    }
}