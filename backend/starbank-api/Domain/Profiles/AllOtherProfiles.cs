

using AutoMapper;
using starbank_api.Domain.Models;

namespace starbank_api.Domain.Profiles;

public class AllOtherProfiles : Profile
{

    public AllOtherProfiles()
    {
        //CreateMap<LegalEntity, LegalEntityResponseDto>();
        CreateMap<LegalEntityRequestDto, LegalEntity>();
        CreateMap<AddressRequestDto, Address>();
        CreateMap<AccountRequestDto, Account>();
    }


}
