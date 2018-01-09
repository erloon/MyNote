﻿using AutoMapper;
using MyNote.Notes.API.Model;
using MyNote.Notes.Domain.Commands;

namespace MyNote.Notes.API.Infrastructure
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<CreateNote, CreateNoteCommand>()
                .ReverseMap();
            CreateMap<UpdateNote, UpdateNoteCommand>()
                .ReverseMap();
            CreateMap<DeleteNote, DeleteNoteCommand>()
                .ReverseMap();
        }
    }
}