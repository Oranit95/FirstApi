using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GithubUsers.Models
{
    public class User
    {
        [JsonPropertyName("login")]
        public string UserName { get; set; }

        [JsonPropertyName("id")]
        public int UserId { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("followers_url")]
        public string Followers { get; set; }

        [JsonPropertyName("following_url")]
        public string Following { get; set; }

        [JsonPropertyName("gists_url")]
        public string Gists { get; set; }

        [JsonPropertyName("starred_url")]
        public string Starred { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string Subscriptions{ get; set; }

        [JsonPropertyName("organizations_url")]
        public string Organizations { get; set; }

        [JsonPropertyName("repos_url")]
        public string Repositories { get; set; }

        [JsonPropertyName("events_url")]
        public string Events { get; set; }

        [JsonPropertyName("received_events_url")]
        public string ReceivedEvents{ get; set; }

        [JsonPropertyName("type")]
        public string UserType { get; set; }

        [JsonPropertyName("site_admin")]
        public bool IstSiteAdmin { get; set; }

        public List<Follower> LFollowers { get; set; }

        public List<Repository> LRepositories { get; set; }
        public User()
        {
            LFollowers = new List<Follower>();
        }
       
    }

    public class Follower
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userType { get; set; }

        public Follower(int id, string name, string userType)
        {
            this.id = id;
            this.name = name;
            this.userType = userType;
        }
    }
}
