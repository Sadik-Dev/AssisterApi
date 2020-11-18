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
    public class ConsultationsController : ControllerBase
    {

        private readonly IConsultationsRepository _consultationsRepository;
        private IUserService _userService;
        private readonly IUserRepository _usersRepository;
        private readonly ICustomerRepository _customerRepository;



        public ConsultationsController(IConsultationsRepository repo,
            IUserService userService,
            IUserRepository userRepository,
            ICustomerRepository customerRepository)
        {
            _consultationsRepository = repo;
            _userService = userService;
            _customerRepository = customerRepository;
            _usersRepository = userRepository;
        }

        // GET: api/Consultations
        /// <summary>
        /// Get all consultations ordered by date
        /// </summary>
        /// <returns>array of consultations</returns>
        [HttpGet]
        public IEnumerable<Consultation> GetConsultations()
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            User user = _usersRepository.GetBy(userId);
            user.LastFetch = DateTime.UtcNow.AddHours(1);

            _usersRepository.SafeUpdate(user);

            Console.WriteLine(user.LastFetch);
            return _consultationsRepository.GetAll().OrderBy(r => r.Date);
        }

        // POST: api/Consultations
        /// <summary>
        /// Make a new Consultation
        /// </summary>
        [HttpPost]
        public IActionResult PostConsultation(Consultation consultation)
        {
            int customerId = consultation.Customer.Id;

            Customer customer = _customerRepository.GetBy(customerId);

            consultation.Customer = customer;

            _consultationsRepository.Add(consultation);
            _consultationsRepository.SaveChanges();
            return CreatedAtAction(nameof(GetConsultation), new { id = consultation.Id }, consultation);

        }

        // GET: api/Consultations/id
        /// <summary>
        /// Get the consultation with given id
        /// </summary>
        /// <param name="id">the id of the consultation</param>
        /// <returns>The consultation</returns>
        [HttpGet("{id}")]
        public ActionResult<Consultation> GetConsultation(int id)
        {
            Consultation consultation = _consultationsRepository.GetBy(id);

            return consultation;

        }
    }
}
