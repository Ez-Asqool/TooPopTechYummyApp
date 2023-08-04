using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.ViewModels.AdminViewModels
{
    public class AddBookVM
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int NumberOfPeople { get; set; }

        public string Message { get; set; }
    }
}
