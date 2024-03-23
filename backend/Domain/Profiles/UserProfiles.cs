using StarBank.Domain.Models;
using StarBank.Domain.DTOs;
using AutoMapper;

namespace StarBank.Domain.Profiles
{
    public class UserProfile : Profile
    {
        protected UserProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}