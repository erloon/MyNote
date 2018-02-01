using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyNote.MVC.Models.DTO;
using MyNote.MVC.Models.VM;

namespace MyNote.MVC.Application
{
    public interface INoteService
    {
        Task<Image> CreateImage(CreateFormFile fileImage);
        Task<List<Image>> CreateImages(CreateImages images);
        Task<File> CreateFile(CreateFormFile createFormFile);
        Task<List<File>> CreateFiles(CreateFiles files);
        Task<Note> CreateNote(CreateNote createNote);
        Note Get(Guid noteId);
    }
}