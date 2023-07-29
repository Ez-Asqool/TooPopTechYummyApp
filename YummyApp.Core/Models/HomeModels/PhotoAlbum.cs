using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class PhotoAlbum //Gallary
    {
        public int Id { get; set; }

        [Required, MaxLength(64)]
        public string Title { get; set; }

        //One-To-Mant relation with Photo
        public List<Photo> Photos { get; set; }

        [Required]
        public int Blocked { get; set; } = 0;
    }
}
