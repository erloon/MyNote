namespace MyNote.Notes.API.Infrastructure
{
    public class EventStoreConfiguration
    {
        public string ConnectionString { get; set; }
        public string SchemaName { get; set; }
    }
}