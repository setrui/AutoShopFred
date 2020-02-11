using AutoShop_Shared.Models;
using System.Collections.Generic;

namespace AutoShop_Shared.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();

        public User GetUser(string id="", string partitionKey="");

        public User InsertUser(User user);

        void DeleteUser(string id1, string partitionKey);
    }
}
