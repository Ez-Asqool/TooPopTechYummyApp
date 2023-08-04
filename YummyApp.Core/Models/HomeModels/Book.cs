using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Models.HomeModels
{
    public class Book
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int  NumberOfPeople { get; set; }

        public string Message { get; set; }

        public int Blocked { get; set; } = 0;
    }
}
