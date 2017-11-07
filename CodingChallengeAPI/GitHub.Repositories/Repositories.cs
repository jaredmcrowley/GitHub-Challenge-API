using GitHub.Repositories.Model;
using GitHub.Repositories.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace GitHub.Repositories
{
    public class Repositories
    {
        public GitHubRepositories GitRepositoriesService(string id)
        {
            try
            {
                var client = RepoClient.RepoClientConnection();
                var repoTierOne = GenerateTierOneRepoList(client, id);
                var repoTierTwo = GenerateTierTwoRepoList(client, repoTierOne.Repositories);
                var finalRepoResult = (from repo in repoTierTwo select repo.Repositories).FirstOrDefault();
                var repoTierThree = GenerateTierThreeRepoList(client, finalRepoResult);
                return new GitHubRepositories()
                {
                    RepositoriesTierOne = repoTierOne,
                    RepositoriesTierTwo = repoTierTwo,
                    RepositoriesTierThree = repoTierThree
                };

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubRepositories();
            }
        }

        private GitHubRepositoriesTierOne GenerateTierOneRepoList(HttpClient client, string id)
        {
            try
            {
                var repositoriesGet = GetGitHubRepo(client, id).Take(3);
                return new GitHubRepositoriesTierOne()
                {
                    UserName = id,
                    Repositories = repositoriesGet.ToList()
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubRepositoriesTierOne();
            }
        }

        private List<GitHubRepositoriesTierTwo> GenerateTierTwoRepoList(HttpClient client, List<GitHubRepoModelBase> repos)
        {
            try
            {
                var repoList = new List<GitHubRepositoriesTierTwo>();
                foreach (var userName in repos)
                {
                    var repoGet = GetGitHubRepo(client, userName.name).Take(3);
                    var repoModel = new GitHubRepositoriesTierTwo()
                    {
                        UserName = userName.name,
                        Repositories = repoGet.ToList()
                    };
                    repoList.Add(repoModel);
                }
                return repoList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubRepositoriesTierTwo>();
            }
        }

        private List<GitHubRepositoriesTierThree> GenerateTierThreeRepoList(HttpClient client, List<GitHubRepoModelBase> repos)
        {
            try
            {
                var repoList = new List<GitHubRepositoriesTierThree>();
                foreach (var userName in repos)
                {
                    var repoGet = GetGitHubRepo(client, userName.name).Take(3);
                    var repoModel = new GitHubRepositoriesTierThree()
                    {
                        UserName = userName.name,
                        Repositories = repoGet.ToList()
                    };
                    repoList.Add(repoModel);
                }
                return repoList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubRepositoriesTierThree>();
            }
        }


        private List<GitHubRepoModelBase> GetGitHubRepo(HttpClient client, string id)
        {
            try
            {
                var repoResults = client.GetAsync(new Uri($"{client.BaseAddress}{id}/repos")).Result;
                var streamResults = repoResults.Content.ReadAsStreamAsync().Result;
                return Deserialize<List<GitHubRepoModelBase>>(streamResults);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubRepoModelBase>();
            }
        }

        private List<GitHubRepoModelBase> Deserialize<T>(Stream stream)
        {
            try
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonText = new JsonTextReader(reader))
                    {
                        var json = new JsonSerializer();
                        return json.Deserialize<List<GitHubRepoModelBase>>(jsonText);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubRepoModelBase>();
            }
        }
    }
}
