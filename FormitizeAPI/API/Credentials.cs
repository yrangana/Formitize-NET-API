using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formitize.API
{
    public class Credentials
    {
        public string CompanyName
        {
            get; set;
        }

        public string UserName
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        /**
            summary 
            The Credentials used for the Formitize API.
        */
        public Credentials(String CompanyName, String UserName, String Password)
        {
            this.CompanyName = CompanyName;
            this.UserName = UserName;
            this.Password = Password;
        }
        
    }
}
