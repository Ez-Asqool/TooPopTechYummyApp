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
    public class UpdateTestimonialVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public int Stars { get; set; }

        public string ImageName { get; set; }

        public IFormFile? Image { get; set; }


    }
}
