using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagueMe.Domain.Interface.Security
{
    public interface IAccount
    {
        public bool PasswordIsValid(string password);

        public string GetIdentityNumber();

    }
}
