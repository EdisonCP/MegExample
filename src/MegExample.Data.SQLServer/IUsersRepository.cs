using System.Collections.Generic;
using System.Linq;
using MegExample.Ifx;

namespace MegExample.Data.SQLServer
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        void SetUserEmail(int userId, string emailAddress);
    }

    public class UsersRepository : IUsersRepository
    {
        public static List<User> Users = new List<User>();

        public UsersRepository()
        {
            Users.Add(new User
            {
                EmailAddress = "chris@inash.net",
                FirstName = "Chris",
                LastName = "Nash", 
                UserId = 1
            });


            Users.Add(new User
            {
                EmailAddress = "anne@inash.net",
                FirstName = "Anne",
                LastName = "Nash",
                UserId = 2
            });

            Users.Add(new User
            {
                EmailAddress = "brian@inash.net",
                FirstName = "Brian",
                LastName = "Nash",
                UserId = 3
            });


            Users.Add(new User
            {
                EmailAddress = "bob@inash.net",
                FirstName = "Bob",
                LastName = "Nash",
                UserId = 4
            });

        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }

        public User GetUser(int userId)
        {
            return Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void SetUserEmail(int userId, string emailAddress)
        {
            var userToUpdate = Users.FirstOrDefault(u => u.UserId == userId);
            if (userToUpdate != null) userToUpdate.EmailAddress = emailAddress;
        }
    }
}