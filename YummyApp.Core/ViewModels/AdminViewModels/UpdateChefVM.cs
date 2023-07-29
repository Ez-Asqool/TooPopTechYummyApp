﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class UpdateChefVM
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Role { get; set; }

        [Required]
        public string ImageName { get; set; }

        public IFormFile? Image { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
