using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models.Repositories
{
    public interface IUserRepository
    {
        public void Add(User user);

        public void Delete(User user);
        public IEnumerable<User> GetAll();
        public User GetBy(int id);

        public void SaveChanges();

        public void Update(User user);
        public void SafeUpdate(User user);
    }
}
