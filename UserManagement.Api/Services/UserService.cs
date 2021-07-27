using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Api.Services
{
    public class UserService
    {
        private List<User> Users { get; set; }
        public UserService()
        {
            this.Users = new List<User>()
            {
                new User { id = 1, vorname = "Nik", nachname= "Müller", geburtsdatum = DateTime.Now.AddYears(-30)},
                new User { id = 2, vorname = "Sara", nachname= "Jafari", geburtsdatum = DateTime.Now.AddYears(-34)},
                new User { id = 3, vorname = "Peter", nachname= "Dessau", geburtsdatum = DateTime.Now.AddYears(-25)}
            };
        }
        public List<User> GetAll()
        {
            return this.Users;
        }
        public User GetById(int id)
        {
            return this.Users.FirstOrDefault(x => x.id == id);
        }
        public bool Create(User user)
        {
            var first = this.Users.OrderByDescending(x => x.id).FirstOrDefault();
            user.id = first != null ? first.id + 1 : 1;
            this.Users.Add(user);
            return true;
        }
        public bool Update(User user)
        {
            var u = this.Users.FirstOrDefault(x => x.id == user.id);
            u.vorname = user.vorname;
            u.nachname = user.nachname;
            u.geburtsdatum = user.geburtsdatum;
            return true;
        }
        public bool Delete(int id)
        {
            var user = this.Users.FirstOrDefault(x => x.id == id);
            return this.Users.Remove(user);
        }
    }
}

