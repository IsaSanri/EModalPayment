﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Final.Entities.DTOs
{
    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
