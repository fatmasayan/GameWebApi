namespace GameWebApi2.Mapping;

public class UserOwendMapProfile : Profile
{
    public UserOwendMapProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<UserOwendMap, UserOwendMapViewModel>();

        CreateMap<UserOwendMapDTO, UserOwendMap>();

        CreateMap<UserOwendMapAddDTO, UserOwendMap>();

        CreateMap<UserOwendMapUpdateDTO, UserOwendMap>();

    }
}
