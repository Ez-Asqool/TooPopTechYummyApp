using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class Photo
    {
        public int Id { get; set; }

        public string PhotoName { get; set; }

        public int PhotoAlbumId { get; set; }

        public PhotoAlbum PhotoAlbum { get; set; }

    }
}
