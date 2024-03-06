
namespace GameWebApi2.Mapping;

public class AuthUserProfile : Profile
{
    public AuthUserProfile()
    {
        CreateMaps();
    }

    
    private void CreateMaps()
    {
        CreateMap<AuthUser, AuthUserViewModel>(); 

        CreateMap<AuthUserDTO, AuthUser>();

        CreateMap<AuthUserAddDTO, AuthUser>();

        CreateMap<AuthUserUpdateDTO, AuthUser>();
    }

}
