using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class DetailsChefVM
    {
    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public string ImageName { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public int Status { get; set; }

    }
}
