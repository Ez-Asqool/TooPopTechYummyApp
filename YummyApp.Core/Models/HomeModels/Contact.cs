using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, MaxLength(32)]
        public string Name { get; set; }

        [Required, MaxLength(64)]
        public string Email { get; set; }

        [Required, Column(TypeName = "nvarchar(1000)")]
        public string Subject { get; set; }

        [Required, Column(TypeName = "nvarchar(2500)")]
        public string Message { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int Blocked { get; set; } = 0;    

    }
}
