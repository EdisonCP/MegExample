using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegExample.Contracts;
using MegExample.Ifx;

namespace MegExample.Managers.ExtensionMethods
{
    public static class UsersExtensionMethods
    {
        public static UserResponse ConvertToResponseObject(this User theUser)
        {
            return new UserResponse
            {
                EmailAddress = theUser.EmailAddress,
                FirstName = theUser.FirstName,
                LastName = theUser.LastName,
                UserId = theUser.UserId
            };
        }

        public static IReadOnlyCollection<UserResponse> ConvertToResponseList(this IEnumerable<User> userList)
        {
            return userList.Select(u => new UserResponse
            {
                EmailAddress = u.EmailAddress,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserId = u.UserId
            }).ToList();
        }
    }
}
