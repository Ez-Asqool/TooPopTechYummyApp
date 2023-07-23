using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;
using YummyApp.Core.ViewModels.HomeViewModels;

namespace YummyApp.Core.Mapper
{
    internal class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ContactVM, Contact>();

            CreateMap<AddEventVM, Event>();

            CreateMap<Event, DetailsEventVM>();

            CreateMap<Event, DeleteEventVM>().ReverseMap();

            CreateMap<Event, UpdateEventVM>().ReverseMap();
        }

    }
}
