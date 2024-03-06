namespace GameWebApi2.Mapping;

public class UserCharProfile : Profile
{

    public UserCharProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<UserChar, UserCharViewModel>();

        CreateMap<UserCharDTO, UserChar>();

        CreateMap<UserCharAddDTO, UserChar>();

        CreateMap<UserCharUpdateDTO, UserChar>();

    }
}
