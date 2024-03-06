namespace GameWebApi2.Mapping;

public class UserBodyTypeProfile : Profile
{

    public UserBodyTypeProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<UserBodyType, UserBodyTypeViewModel>();

        CreateMap<UserBodyTypeDTO, UserBodyType>();

        CreateMap<UserBodyTypeAddDTO, UserBodyType>();

        CreateMap<UserBodyTypeUpdateDTO, UserBodyType>();

    }
}
