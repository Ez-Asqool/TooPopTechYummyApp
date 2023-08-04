using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;
using YummyApp.Core.ViewModels.ChefViewModels;
using YummyApp.Core.ViewModels.HomeViewModels;
using YummyApp.EF.Data;

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

            CreateMap<ApplicationUser, DetailsChefVM>();

            CreateMap<ApplicationUser, UpdateChefVM>().ReverseMap();

            CreateMap<AddMealVM, Meal>()
           .ForMember(dest => dest.Category, opt => opt.Ignore());

			CreateMap<Meal, DetailsMealVM>()
	        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
	        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<Meal, UpdateMealVM>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<UpdateMealVM, Meal>()
           .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<AddBookVM, Book>();

        }

    }
}
