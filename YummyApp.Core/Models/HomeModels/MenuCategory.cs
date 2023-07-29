using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class MenuCategory
    {

        public int Id { get; set; }

        [Required, MaxLength(16)]
        public string Name { get; set; }


        //one-to-many relation with Meal
        public List<Meal> Meals { get; set; }

        [Required]
        public int Blocked { get; set; } = 0;
    }
}
