using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formitize.API.REST
{
    public class FormitizeCredentials
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
        public FormitizeCredentials(String CompanyName, String UserName, String Password)
        {
            this.CompanyName = CompanyName;
            this.UserName = UserName;
            this.Password = Password;
        }
        
    }
}
