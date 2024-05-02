namespace PagueMe.Domain.Interface.Security
{
    public interface IAccount
    {
        public bool PasswordIsValid(string password);

        public string GetIdentityNumber();

    }
}
