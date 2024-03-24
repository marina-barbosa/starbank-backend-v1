

using AutoMapper;
using starbank_api.Domain.Models;

namespace starbank_api.Domain.Profiles;

public class CustomerProfiles : Profile
{

    public CustomerProfiles()
    {
        CreateMap<Customer, CustomerResponseDto>();
        CreateMap<CustomerRequestDto, Customer>();
    }

    //     public class UserProfile : Profile
    //     {
    //         protected UserProfile()
    //         {
    //             CreateMap<RegisterDto, User>();
    //         }
    //     }

}
