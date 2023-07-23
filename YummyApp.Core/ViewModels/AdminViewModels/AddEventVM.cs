using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class AddEventVM
    {
        [Required, MaxLength(64)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required, MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
