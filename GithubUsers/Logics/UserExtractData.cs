using GithubUsers.Models;
using GithubUsers.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubUsers.Logics
{
    public class UserExtractData: IUserExtractData
    {
        private readonly IGitHubUsersRepository _gitUsers;

        private string domain { get; set; }
        public UserExtractData(IConfiguration configuration)
        {
            _gitUsers = new GitHubUsersRepository();
            domain = configuration.GetSection("AppSettings:GitHub:Domain")?.Value;
        }
        public UserExtractData()
        {

        }
        public async Task<List<User>> GetUsersRepositories()
        {
                var users = await _gitUsers.GetUsersFromGitHub($"{domain}?since=100");
                var usertype = users.Where(u => u.UserType == "User");
                List<Repository> repos = new List<Repository>();
                foreach (var user in usertype)
                {
                    user.LRepositories = await _gitUsers.GetUserRepositories($"{domain}{user.Repositories}");
                }
                return usertype.ToList();

        }

        public Task<IEnumerable<User>> GetUserInfo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
