using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using YummyApp.app.Data;

namespace YummyApp.Core.Models.HomeModels
{
    public class Meal
    {
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public int CategoryId { get; set; }
        public MenuCategory Category { get; set; }

        [Required]
        public int Blocked { get; set; } = 0;

        public string ApplicationUserId { get; set; } //to connect Meal with its Chef
        public virtual ApplicationUser User { get; set; }
    }
}
