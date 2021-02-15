﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerCropMarketing.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirem Password and Pasword must same.")]
        [Display(Name ="Confirem Password")]
        public string ConfirmPassword { get; set; }
    }
}
