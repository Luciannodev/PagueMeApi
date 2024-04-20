namespace PagueMe.DataProvider.Config
{
    public class DataBaseSettings
    {
        public Database Database;
    }

    public class Database
    {
        public string ENDPOINT { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
}
