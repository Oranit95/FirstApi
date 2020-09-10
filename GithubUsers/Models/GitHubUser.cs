using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubUsers.Models
{
    public class GitHubUser
    {
        public string UserName { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string AvatarURL { get; set; }
        public string GravateId { get; set; }
        public string URLApi { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }




    }
}
