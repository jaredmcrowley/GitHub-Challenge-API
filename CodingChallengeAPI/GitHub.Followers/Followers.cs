using GitHub.Followers.Model;
using GitHub.Followers.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;

namespace GitHub.Followers
{
    public class Followers
    {
        public GitHubFollowers GitHubFollowersService(string id)
        {
            try
            {
                var client = FollowerClient.FollowerClientConnection();
                var followersTierOne = GenerateTierOneFollowersList(client, id);
                var followersTierTwo = GenerateTierTwoFollowersList(client, followersTierOne.Followers);
                var finalFollowers = (from followers in followersTierTwo select followers.Followers).FirstOrDefault();
                var followersTierThree = GenerateTierThreeFollowersList(client, finalFollowers);
                return new GitHubFollowers()
                {
                    FollowersTierOne = followersTierOne,
                    FollowersTierTwo = followersTierTwo,
                    FollowersTierThree = followersTierThree
                };

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubFollowers();
            }      
        }

        private GitHubFollowerTierOne GenerateTierOneFollowersList(HttpClient client, string id)
        {
            try
            {
                var followersGet = GetGitHubFollowers(client, id).Take(3);
                return new GitHubFollowerTierOne()
                {
                    UserName = id,
                    Followers = followersGet.ToList()
                };
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new GitHubFollowerTierOne();
            }
        }

        private List<GitHubFollowerTierTwo> GenerateTierTwoFollowersList(HttpClient client ,List<GitHubFollowerModelBase> followers)
        {
            try
            {
                var followersList = new List<GitHubFollowerTierTwo>();
                foreach (var userName in followers)
                {
                    var followersGet = GetGitHubFollowers(client, userName.login).Take(3);
                    var followersModel = new GitHubFollowerTierTwo()
                    {
                        UserName = userName.login,
                        Followers = followers.ToList()
                    };
                    followersList.Add(followersModel);
                }
                return followersList;
            }  
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubFollowerTierTwo>();
            }  
        }

        private List<GitHubFollowerTierThree> GenerateTierThreeFollowersList(HttpClient client, List<GitHubFollowerModelBase> followers)
        {
            try
            {
                var followersList = new List<GitHubFollowerTierThree>();
                foreach (var userName in followers)
                {
                    var followersGet = GetGitHubFollowers(client, userName.login).Take(3);
                    var folowersModel = new GitHubFollowerTierThree()
                    {
                        UserName = userName.login,
                        Followers = followersGet.ToList()
                    };
                    followersList.Add(folowersModel);
                }
                return followersList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubFollowerTierThree>();
            }
        }

        private List<GitHubFollowerModelBase> GetGitHubFollowers(HttpClient client, string id)
        {
            try
            {
                var followersGet = client.GetAsync(new Uri($"{client.BaseAddress}{id}/followers")).Result;
                var streamResults = followersGet.Content.ReadAsStreamAsync().Result;
                return Deserialize<List<GitHubFollowerModelBase>>(streamResults);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubFollowerModelBase>();
            }            
        }

        private List<GitHubFollowerModelBase> Deserialize<T>(Stream stream)
        {
            try
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonText = new JsonTextReader(reader))
                    {
                        var json = new JsonSerializer();
                        return json.Deserialize<List<GitHubFollowerModelBase>>(jsonText);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return new List<GitHubFollowerModelBase>();
            }            
        }
    }
}
