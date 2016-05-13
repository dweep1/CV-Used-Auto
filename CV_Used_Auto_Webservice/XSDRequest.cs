using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceStackTemplate
{
    
    public class UserRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class GenRequest
    {
        public string username { get; set; }
        public string password { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zipcode { get; set; }


    }

    public class EmptyRequest
    {

    }

    public class ContactRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Message { get; set; }

    }
}


