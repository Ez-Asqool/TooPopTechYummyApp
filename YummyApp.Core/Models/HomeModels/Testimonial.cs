using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class Testimonial
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string JobTitle { get; set; }

        [Required, Column(TypeName = "nvarchar(2500)")]
        public string Description { get; set; }

        [Required, MaxLength(5) ]
        public int Stars { get; set; }


        [Required]
        public string ImageName { get; set; }

        [Required]
        public int Status { get; set; } = 1;

        [Required]
        public int Blocked { get; set; } = 0;

    }

   
}
