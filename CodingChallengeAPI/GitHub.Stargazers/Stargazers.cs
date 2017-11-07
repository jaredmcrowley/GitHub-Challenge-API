using GitHub.Stargazers.Model;
using GitHub.Stargazers.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace GitHub.Stargazers
{
    public class Stargazers
    {
        public GitHubStargazer GitHubStargazerService(string id, string repoName)
        {
            try
            {
                var client = StargazerClient.StargazerClientConnection();
                return GenerateTierOneStarGazerList(client, id, repoName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubStargazer();
            }
        }

        private GitHubStargazer GenerateTierOneStarGazerList(HttpClient client, string id, string repoName)
        {
            try
            {
                var starGazerGet = GetGitHubStarGazer(client, id, repoName).Take(3);
                return new GitHubStargazer()
                {
                    UserName = id,
                    StarGazer = starGazerGet.ToList()
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubStargazer();
            }
        }

        private List<GitHubStargazerModelBase> GetGitHubStarGazer(HttpClient client, string id, string repoName)
        {
            try
            {
                var stargazerResults = client.GetAsync(new Uri($"{client.BaseAddress}{id}/{repoName}/stargazers")).Result;
                var streamResults = stargazerResults.Content.ReadAsStreamAsync().Result;
                return Deserialize<List<GitHubStargazerModelBase>>(streamResults);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubStargazerModelBase>();
            }
        }

        private List<GitHubStargazerModelBase> Deserialize<T>(Stream stream)
        {
            try
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonText = new JsonTextReader(reader))
                    {
                        var json = new JsonSerializer();
                        return json.Deserialize<List<GitHubStargazerModelBase>>(jsonText);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubStargazerModelBase>();
            }
        }
     }
}
