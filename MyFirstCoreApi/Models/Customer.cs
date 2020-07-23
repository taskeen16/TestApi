﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFirstCoreApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,StringLength(15)]
        public string Name { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Email in not valid")]        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
