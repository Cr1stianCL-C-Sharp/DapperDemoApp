﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Dapper_DEMO.Models
{
    public class EmpModel
    {
        //[Key]
        [Display(Name = "Id")]
        public int Empid { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}