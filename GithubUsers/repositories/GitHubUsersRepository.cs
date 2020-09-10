using GithubUsers.Models;
using GithubUsers.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GithubUsers
{
    public class GitHubUsersRepository : IGitHubUsersRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public IEnumerable<User> users { get; private set; }
        public IEnumerable<Repository> repositories { get; private set; }
            
        public GitHubUsersRepository(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
        }

        public GitHubUsersRepository()
        {
        }

        public async Task<List<User>> GetUsersFromGitHub(String api)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, api);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                users = await JsonSerializer.DeserializeAsync
                    <IEnumerable<User>>(responseStream);
            }
            else
            {
                users = Array.Empty<User>();
            }
            return users.ToList();
        }
        public async Task<List<Repository>> GetUserRepositories(string RepositoryApi)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RepositoryApi);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                repositories = await JsonSerializer.DeserializeAsync
                    <IEnumerable<Repository>>(responseStream, options);
            }
            else
            {
              //  GetUsersError = true;
                repositories = Array.Empty<Repository>();
            }
            return repositories.ToList();
        }



        //Task IGitHubUsersRepository.GetUsersFromGitHub()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
