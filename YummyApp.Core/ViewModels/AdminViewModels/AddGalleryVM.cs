using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.HomeModels;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class AddGalleryVM
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public List<IFormFile> Photos { get; set; }

    }
}
