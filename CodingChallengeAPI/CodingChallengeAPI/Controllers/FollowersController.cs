using Microsoft.AspNetCore.Mvc;
using GitHub.Followers;
using GitHub.Followers.Model;

namespace CodingChallengeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Followers")]
    public class FollowersController : Controller
    {
        [HttpGet("{id}")]
        public GitHubFollowers GetFollowers(string id)
        {
            var followers = new Followers();
            var followersResults = followers.GitHubFollowersService(id);
            return followersResults;
        }
    }
}