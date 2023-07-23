using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.ViewModels.HomeViewModels
{
    public class ContactVM
    {

        [Required, MaxLength(32)]
        public string Name { get; set; }

        [Required, MaxLength(64)]
        public string Email { get; set; }

        [Required, MaxLength(1000)]
        public string Subject { get; set; }

        [Required, MaxLength(2500)]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
