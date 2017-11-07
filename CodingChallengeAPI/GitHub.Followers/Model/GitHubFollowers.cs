using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Followers.Model
{
    public class GitHubFollowers
    {
        public GitHubFollowers()
        {
            FollowersTierOne = new GitHubFollowerTierOne();
            FollowersTierTwo = new List<GitHubFollowerTierTwo>();
            FollowersTierThree = new List<GitHubFollowerTierThree>();
        }
        public GitHubFollowerTierOne FollowersTierOne { get; set; }
        public List<GitHubFollowerTierTwo> FollowersTierTwo { get; set; }
        public List<GitHubFollowerTierThree> FollowersTierThree { get; set; }
    }

    public class GitHubFollowerTierOne
    {
        public GitHubFollowerTierOne()
        {
            Followers = new List<GitHubFollowerModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubFollowerModelBase> Followers { get; set; }
    }

    public class GitHubFollowerTierTwo
    {
        public GitHubFollowerTierTwo()
        {
            Followers = new List<GitHubFollowerModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubFollowerModelBase> Followers { get; set; }
    }

    public class GitHubFollowerTierThree
    {
        public GitHubFollowerTierThree()
        {
            Followers = new List<GitHubFollowerModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubFollowerModelBase> Followers { get; set; }
    }

    public class GitHubFollowerModelBase
    {
        public string login { get; set; }
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string gravater_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
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
