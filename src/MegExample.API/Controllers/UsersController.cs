using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MegExample.Contracts;
using MegExample.Managers;

namespace MegExample.API.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUsersManager _usersManager;
        public UsersController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        [Route("{userId:int}"), HttpGet, ResponseType(typeof(UserResponse))]
        public IHttpActionResult GetUser(int userId)
        {
            var user = _usersManager.GetUser(userId);
            return Ok(user);
        }


        [Route(""), HttpGet, ResponseType(typeof(IEnumerable<UserResponse>))]
        public IHttpActionResult GetUsers()
        {
            var users = _usersManager.GetUsers();
            return Ok(users);
        }

        [Route("{userid:int}/Email"), HttpPost]
        public IHttpActionResult SetEmail(int userId, UpdateUserEmailRequest emailAddressRequest)
        {
            _usersManager.SetUserEmail(userId, emailAddressRequest);
            return Ok();
        }
    }
}
