using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.AdminModels
{
    public class Event
    {
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required, MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        public string ImageName { get; set; }
    }
}
