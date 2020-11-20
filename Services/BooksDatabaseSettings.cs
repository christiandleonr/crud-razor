namespace crudnetcore.Services
{
    public class BooksDatabaseSettings : IBooksDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IBooksDatabaseSettings
    {
        string ConnectionString {get; set;}

        string DatabaseName {get; set;}
    }
}