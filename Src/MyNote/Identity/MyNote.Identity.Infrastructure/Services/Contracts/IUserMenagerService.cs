using System;

namespace MyNote.Identity.Infrastructure.Services.Contracts
{
    public interface IUserMenagerService
    {
        Guid GetUserId(string name);
    }
}