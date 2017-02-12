using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegExample.Contracts
{
    public class UpdateUserEmailRequest: CommandContractBase
    {
        public string EmailAddress { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(EmailAddress))
                throw new ArgumentNullException($"Email Address Is  Required");

        }
    }

    public class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
    
}
