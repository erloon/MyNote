namespace MyNote.Identity.API.Infrastructure.Configs
{
    public class AppSettings
    {
        public string SpaUI { get; set; }

        public bool UseCustomizationData { get; set; }
        public EventStoreConfiguration EventStoreConfiguration { get; set; }
    }
}