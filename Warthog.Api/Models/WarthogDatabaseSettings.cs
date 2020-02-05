namespace Warthog.Api.Models
{
    public class WarthogDatabaseSettings : IWarthogDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IWarthogDatabaseSettings
    {
        string StudentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
