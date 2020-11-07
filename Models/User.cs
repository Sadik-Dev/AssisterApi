
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssisterApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        [JsonIgnore]
        public String Password { get; set; }
        public String Token { get; set; }
        public DateTime LastFetch { get; set; }

        public User(String name, String email, String password)
        {
            Name = name;
            Email = email;
            Password = password;
            LastFetch = DateTime.UtcNow.AddHours(1);
         
        }

    }
}
