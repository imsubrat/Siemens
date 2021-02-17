using System;
using System.Collections.Generic;
using System.Linq;
using Siemens.Entity;
using Siemens.Helper;

namespace Siemens.Service
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.username == username && x.password==password);

            // check if username exists
            if (user == null)
                return null;

            // authentication successful
            return user;
        }
    }
}