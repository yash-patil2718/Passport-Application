using AutoMapper;
using PassportWebApplication.DTO.Feedback;
using PassportWebApplication.DTO.NewApplication;
using PassportWebApplication.Models;

namespace PassportWebApplication.Automapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            //new application dto's
            CreateMap<ServiceRquired, ServiceRequiredDto>().ReverseMap();
            CreateMap<ApplicantDetails, ApplicantDetailsDto>().ReverseMap();
            CreateMap<FamilyDetails, FamilyDetailsDto>().ReverseMap();
            CreateMap<ResidentialDetails, ResidentialDetailsDto>().ReverseMap();
            CreateMap<EmergencyDetails, EmergencyDetailsDto>().ReverseMap();
            CreateMap<OtherDetails, OtherDetailsDto>().ReverseMap();
            CreateMap<Documents, DocumentDetailsDto>().ReverseMap();

            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<Feedback, AdminFeedbackDto>().ReverseMap();
        }
    }
}
