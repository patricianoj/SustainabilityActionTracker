using System;
using System.Collections.Generic;
using System.Linq;

namespace MissionSustainability.Models
{
    public class DBUserRepository : IUserRepository
    {
        private readonly RDSContext context;

        public DBUserRepository(RDSContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            User foundUser = context.Users.Find(user);
            if (foundUser != null)
            {
                context.Users.Remove(foundUser);
                context.SaveChanges();
            }
            return foundUser;
        }

        public List<Badge> GetAdminBadges()
        {
            var users = GetAllUsers();
            var admin = users.FirstOrDefault(u => u.isAdmin == true);
            return admin.badges;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(string email)
        {
            return context.Users.Find(email);
        }

        public User Update(User userChanges)
        {
            var user = context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
