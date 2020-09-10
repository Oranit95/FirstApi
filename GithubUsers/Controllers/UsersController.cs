using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubUsers.Logics;
using GithubUsers.Models;
using GithubUsers.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GithubUsers.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserExtractData _dataService;

        public UsersController(IUserExtractData dataService, IConfiguration configuration)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var usertype = await _dataService.GetUsersRepositories();
                if(usertype != null) {
                    return Ok(usertype);
                }
                return StatusCode(500, "server error");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Exception - {ex.Message}");
            }

        }

        //[HttpGet("{name}")]
        //public async Task<ActionResult<IEnumerable<User>>> GetUserInfo(string name)
        //{

        //    var users = await _dataService.GetUsersFromGitHub(name);
        //    var usertype = users.Where(u => u.UserName == name);
        //    if (usertype.Count() == 0)
        //    {
        //        return NotFound("No user in that name");
        //    }
        //    foreach (var user in usertype)
        //    {
        //        var followers = await _gitUsers.GetUsersFromGitHub(user.Followers);
        //        foreach (var follower in followers)
        //        {
        //            user.LFollowers.Add(new Follower(follower.UserId, follower.UserName, follower.UserType));
        //        }
        //    }
        //    return Ok(usertype);
        //}


    }
}
