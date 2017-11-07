using Microsoft.AspNetCore.Mvc;
using GitHub.Stargazers;
using GitHub.Stargazers.Model;

namespace CodingChallengeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Stargazers")]
    public class StargazersController : Controller
    {
        [HttpGet("{id}/{repoName}")]
        public GitHubStargazer GetStarGazer(string id, string repoName)
        {
            var stargazer = new Stargazers();
            var stargazerReturn = stargazer.GitHubStargazerService(id, repoName);
            return stargazerReturn;
        }
    }
}