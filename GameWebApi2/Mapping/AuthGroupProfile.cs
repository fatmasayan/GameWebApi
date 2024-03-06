namespace GameWebApi2.Mapping;

public class AuthGroupProfile :Profile
{
    public AuthGroupProfile()
    {
        CreateMaps();

    }
    private void CreateMaps()
    {
        CreateMap<AuthGroup, AuthGroupViewModel>();
        CreateMap<AuthGroupDTO, AuthGroup>();

        CreateMap<AuthGroupAddDTO, AuthGroup>();


        CreateMap<AuthGroupUpdateDTO, AuthGroup>();
    }
}
