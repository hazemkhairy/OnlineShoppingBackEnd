﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSBE.DTOs
{
    public class UserDTO
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}