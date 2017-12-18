namespace MyNote.Identity.API.Infrastructure.Configs
{
    public class EventStoreConfiguration
    {
        public string ConnectionString { get; set; }
        public string SchemaName { get; set; }
    }
}