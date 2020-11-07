using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AssisterApi.Data;
using AssisterApi.DTOs;
using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssisterApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _usersRepository;
        private IUserService _userService;


        public UsersController(IUserRepository userRepository,
            IUserService userService)
        {
            _usersRepository = userRepository;
            _userService = userService;
        }


        // GET: api/Users/id
        /// <summary>
        /// Get the user with given id
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <returns>The User</returns>
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User employee;

            if (id == -1) employee = _usersRepository.GetBy(id);
            else
                employee = _usersRepository.GetBy(id);


            if (employee == null)
                return NotFound();


            return employee;

        }

        // POST: api/Employees/authenticate
        /// <summary>
        /// Login
        /// </summary>
        /// <returns>The logged in employee</returns>
             [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody] LoginDTO model)
            {
                var user = _userService.Authenticate(model.Email, model.Password);
                if (user == null)
                    return BadRequest(new { message = "Email or password is incorrect" });

                return Ok(user);
            }

        // POST: api/Employees
        /// <summary>
        /// Make a new User
        /// </summary>
        [Authorize]
        [HttpPost]
        public IActionResult PostEmployee(User employee)
        {
            String password = employee.Password;
            employee.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            _usersRepository.Add(employee);
            _usersRepository.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = employee.Id }, employee);

        }
    }
}
