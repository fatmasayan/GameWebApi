namespace GameWebApi2.Mapping;

public class UserOwendGarageProfile : Profile
{
    public UserOwendGarageProfile()
    {
        CreateMaps();
    }


    private void CreateMaps()
    {
        CreateMap<UserOwendGarage, UserOwendGarageViewModel>();

        CreateMap<UserOwendGarageDTO, UserOwendGarage>();

        CreateMap<UserOwendGarageAddDTO, UserOwendGarage>();

        CreateMap<UserOwendGarageUpdateDTO, UserOwendGarage>();

    }
}
