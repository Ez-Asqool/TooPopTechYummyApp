using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.HomeModels;

namespace YummyApp.Core.ViewModels.ChefViewModels
{
    public class AddMealVM
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public IFormFile Image { get; set; }

        public string Category { get; set; }

        public string Ingredients { get; set; }
    }
}
