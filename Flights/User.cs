using System;
using System.Collections.Generic;
using System.Text;

namespace Flights
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int Cash { get; set; }

        public User()
        {
            this.Cash = 133000;
        }
    }
}
