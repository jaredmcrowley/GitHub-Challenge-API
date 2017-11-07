using GitHub.Repositories;
using GitHub.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallengeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Repo")]
    public class RepoController : Controller
    {
        [HttpGet("{id}")]
        public GitHubRepositories GetRepo(string id)
        {
            var repo = new Repositories();
            var repoResults = repo.GitRepositoriesService(id);
            return repoResults;
        }
    }
}