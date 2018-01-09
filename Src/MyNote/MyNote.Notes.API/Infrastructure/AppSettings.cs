namespace MyNote.Notes.API.Infrastructure
{
    public class AppSettings
    {
        public bool UseCustomizationData { get; set; }
        public EventStoreConfiguration EventStoreConfiguration { get; set; }
    }
}