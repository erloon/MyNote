using System.Net;

namespace MyNote.MVC.Infrastructure
{
    public interface IStoreService
    {
        Cookie Cookie { get; set; }
    }
}