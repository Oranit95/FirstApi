using GithubUsers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubUsers.Service
{
    public interface IGitHubUsersRepository
    {

        public Task<List<User>> GetUsersFromGitHub(String api);
        public Task<List<Repository>> GetUserRepositories(string RepositoryApi);

    }
}
