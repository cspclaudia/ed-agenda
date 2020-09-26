namespace Agenda.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string LinkedListCollectionName { get; set; }
        public string ContatosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string LinkedListCollectionName { get; set; }
        string ContatosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}