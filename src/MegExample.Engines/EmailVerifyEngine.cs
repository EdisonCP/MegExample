using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MegExample.Engines
{
    public class EmailVerifyEngine : IEmailVerifyEngine
    {
        private const string EmailExpression =
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public bool IsEmailValid(string emailString)
        {
            var isEmail = Regex.IsMatch(emailString, EmailExpression , RegexOptions.IgnoreCase);
            return isEmail;
        }
    }

    public interface IEmailVerifyEngine
    {
        bool IsEmailValid(string emailString);
    }
}
