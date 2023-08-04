using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.Core.ViewModels.HomeViewModels
{
    public class IndexVM
    {
        public PhotoAlbum? PhotoAlbum { get; set; }

        public AddBookVM AddBookVM { get; set; }

    }
}
