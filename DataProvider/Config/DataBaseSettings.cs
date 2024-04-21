namespace PagueMe.DataProvider.Config
{
    public class DataBaseSettings
    {
        public Database Database { get; set; }
    }

    public class Database
    {
        public string Server { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
}
