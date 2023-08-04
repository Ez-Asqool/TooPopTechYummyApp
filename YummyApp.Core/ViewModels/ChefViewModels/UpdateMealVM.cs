using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.Models;
using Microsoft.AspNetCore.Http;

namespace YummyApp.Core.ViewModels.ChefViewModels
{
    public class UpdateMealVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageName { get; set; }

        public IFormFile? Image { get; set; }    

        public string Ingredients { get; set; }

        public string Category { get; set; }


    }
}
