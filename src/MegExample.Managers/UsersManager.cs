using System;
using System.Collections.Generic;
using System.Linq;
using MegExample.Contracts;
using MegExample.Data.SQLServer;
using MegExample.Engines;
using MegExample.Managers.ExtensionMethods;

namespace MegExample.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository _usersRepo;
        private readonly IEmailVerifyEngine _emailVerifyEngine;

        public UsersManager(IUsersRepository usersRepo, IEmailVerifyEngine emailVerifyEngine)
        {
            _usersRepo = usersRepo;
            _emailVerifyEngine = emailVerifyEngine;
        }

        public IEnumerable<UserResponse> GetUsers()
        {
            var usersList = _usersRepo.GetUsers();
            return usersList.ConvertToResponseList();
        }

        public UserResponse GetUser(int userId)
        {
            var theUser = _usersRepo.GetUser(userId);
            return theUser.ConvertToResponseObject();
        }

        public void SetUserEmail(int userId, UpdateUserEmailRequest updateRequest)
        {
            if (!_emailVerifyEngine.IsEmailValid(updateRequest.EmailAddress))
                throw new ApplicationException("Invalid Email Address");

            _usersRepo.SetUserEmail(userId, updateRequest.EmailAddress);
        }
    }

    public interface IUsersManager
    {
        IEnumerable<UserResponse> GetUsers();
        UserResponse GetUser(int userId);

        void SetUserEmail(int userId, UpdateUserEmailRequest updateRequest);
    }
}
