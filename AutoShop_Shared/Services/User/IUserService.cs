using AutoShop_Shared.Models;
using System.Collections.Generic;

namespace AutoShop_Shared.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();

        public User GetUser(string id="", string partitionKey="");
    }
}
