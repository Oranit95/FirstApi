using GithubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubUsers.Logics
{
    public interface IUserExtractData
    {
        public  Task<List<User>> GetUsersRepositories();
        public  Task<IEnumerable<User>> GetUserInfo(string name);

    }
}
