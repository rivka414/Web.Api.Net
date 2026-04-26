using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Web_api_queuies.Model;

namespace TipatCholAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // מיפויים דו-כיווניים בין ישות ל-DTO
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Baby, BabyDTO>().ReverseMap();
            CreateMap<Nurse, NurseDTO>().ReverseMap();

            // מיפויים ממודל פוסט לישות (עבור יצירה ועדכון)
            CreateMap<AppointmentPostModel, Appointment>();
            CreateMap<BabyPostModel, Baby>();
            CreateMap<NursePostModel, Nurse>();
        }
    }
}