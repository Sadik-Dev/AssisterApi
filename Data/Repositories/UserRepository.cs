using AssisterApi.Models;
using AssisterApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AssisterContext _context;
        private readonly DbSet<User> _users;


        public UserRepository(AssisterContext dbContext)
        {
            _context = dbContext;
            _users = _context.Users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetBy(int id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void SafeUpdate(User user)
        {
            _context.SafeUpdate(user);
            _context.FirstSave();
        }
    }
}
