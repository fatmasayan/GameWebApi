namespace GameWebApi2.Mapping;

public class UserBikesProfile : Profile
{
    public UserBikesProfile()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<UserBikes, UserBikesViewModel>();

        CreateMap<UserBikesDTO, UserBikes>();

        CreateMap<UserBikesAddDTO, UserBikes>();

        CreateMap<UserBikesUpdateDTO, UserBikes>();

    }
}
