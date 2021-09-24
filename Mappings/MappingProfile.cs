using AutoMapper;
using BeMyTeacher.ViewModels;
using Meditatori.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeMyTeacher.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ad, AdViewModel>()
                .ForMember(dest => dest.Loaction, opt => opt.MapFrom(src => src.Location.name))
                .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.EducationLevel.name))
                .ForMember(dest => dest.Calification, opt => opt.MapFrom(src => src.Calification.name))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject.Name));

            CreateMap<Subject, SubjectViewModel>();


            //CreateMap<AdViewModel, Ad>();
            //CreateMap<List<Ad>, List<AdViewModel>>();
            //CreateMap<List<AdViewModel>,List<Ad>> ();
        }
    }
}
