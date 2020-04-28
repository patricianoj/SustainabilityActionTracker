using System;
using System.Collections.Generic;

namespace MissionSustainability.Models
{
    public interface IUserRepository
    {
        User GetUser(string email);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User userChanges);
        User Delete(User user);
    }
}
