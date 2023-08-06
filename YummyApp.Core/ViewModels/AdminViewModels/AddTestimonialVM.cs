using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class AddTestimonialVM
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string JobTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Stars { get; set; }

        public IFormFile Image { get; set; }

    }
}
