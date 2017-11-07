using System;
using System.Collections.Generic;

namespace GitHub.Repositories.Model
{
    public class GitHubRepositories
    {
        public GitHubRepositories()
        {
            RepositoriesTierOne = new GitHubRepositoriesTierOne();
            RepositoriesTierTwo = new List<GitHubRepositoriesTierTwo>();
            RepositoriesTierThree = new List<GitHubRepositoriesTierThree>();
        }
        public GitHubRepositoriesTierOne RepositoriesTierOne { get; set; }
        public List<GitHubRepositoriesTierTwo> RepositoriesTierTwo { get; set; }
        public List<GitHubRepositoriesTierThree> RepositoriesTierThree { get; set; }
    }

    public class GitHubRepositoriesTierOne
    {
        public GitHubRepositoriesTierOne()
        {
            Repositories = new List<GitHubRepoModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubRepoModelBase> Repositories { get; set; }
    }

    public class GitHubRepositoriesTierTwo
    {
        public GitHubRepositoriesTierTwo()
        {
            Repositories = new List<GitHubRepoModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubRepoModelBase> Repositories { get; set; }
    }

    public class GitHubRepositoriesTierThree
    {
        public GitHubRepositoriesTierThree()
        {
            Repositories = new List<GitHubRepoModelBase>();
        }
        public string UserName { get; set; }
        public List<GitHubRepoModelBase> Repositories { get; set; }
    }

    public class GitHubRepoModelBase
    {
        public GitHubRepoModelBase()
        {
            owner = new GitHubOwner();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public GitHubOwner owner { get; set; }
        public bool @private { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string keys_url { get; set; }
        public string collaborators_url { get; set; }
        public string teams_url { get; set; }
        public string hooks_url { get; set; }
        public string issue_events_url { get; set; }
        public string events_url { get; set; }
        public string assignees_url { get; set; }
        public string branches_url { get; set; }
        public string tags_url { get; set; }
        public string blobs_url { get; set; }
        public string git_tags_url { get; set; }
        public string git_refs_url { get; set; }
        public string trees_url { get; set; }
        public string statuses_url { get; set; }
        public string languages_url { get; set; }
        public string stargazers_url { get; set; }
        public string contributors_url { get; set; }
        public string subscribers_url { get; set; }
        public string subscription_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string comments_url { get; set; }
        public string issue_comment_url { get; set; }
        public string contents_url { get; set; }
        public string compare_url { get; set; }
        public string merges_url { get; set; }
        public string archive_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string milestones_url { get; set; }
        public string notifications_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public string deployments_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
        public string git_url { get; set; }
        public string ssh_url { get; set; }
        public string clone_url { get; set; }
        public string svn_url { get; set; }
        public object homepage { get; set; }
        public int size { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public string language { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_downloads { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public int forks_count { get; set; }
        public object mirror_url { get; set; }
        public int open_issues_count { get; set; }
        public int forks { get; set; }
        public int open_issues { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; }
    }
}
