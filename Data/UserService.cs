using AssisterApi.Helpers;
using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssisterApi.Data
{
    public class UserService : IUserService
    {

        private readonly AssisterContext _context;
        private IEnumerable<User> _users;
        private readonly AppSettings _appSettings;

        public UserService(AssisterContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _users = context.Users;
            _appSettings = appSettings.Value;

        }

        public User Authenticate(string username, string password)
        {
            string passEncypted =  Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            var user = _users.SingleOrDefault(x => x.Email == username && x.Password == passEncypted);

            // return null if user not found
            if (user == null)
                return null;

          
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            Claim claim;

                claim = new Claim(ClaimTypes.Role, "Doctor");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    claim,
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

        }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            Console.WriteLine("log: " + claim);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;

        }
        
    }
}
