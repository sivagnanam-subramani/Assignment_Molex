using System;
using System.Net.Mail;

namespace Assignment.Common.Constants
{
    public static class AppConstants
    {
        #region common Functions
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress mail = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion
    }
}
