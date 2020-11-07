using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AssisterApi.Data;
using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UpdateLogsController : ControllerBase
    {
        private IUserService _userService;
        private readonly IUserRepository _usersRepository;
        private readonly IUpdateLogsRepository _updateLogsRepository;


        public UpdateLogsController(IUserService userService,
            IUserRepository userRepository, IUpdateLogsRepository updateLogsRepo)
        {
            _userService = userService;
            _usersRepository = userRepository;
            _updateLogsRepository = updateLogsRepo;
        }


        // GET: api/UpdateLogs
        /// <summary>
        /// Know if user is up to date
        /// </summary>
        /// <returns>True or false</returns>
        [HttpGet]
        public Boolean isUserUpToDate()
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            User user = _usersRepository.GetBy(userId);


            int res = DateTime.Compare(user.LastFetch, _updateLogsRepository.Get().LastModification );
            Console.WriteLine(user.LastFetch + " " + _updateLogsRepository.Get().LastModification);
            Console.WriteLine(res);
            if (res < 0)
                return false;
            else
                return true;
        }
    }
}
