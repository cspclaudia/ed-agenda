namespace Agenda.Models
{
    public class AgendaDatabaseSettings : IAgendaDatabaseSettings
    {
        public string ContatosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAgendaDatabaseSettings
    {
        string ContatosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}