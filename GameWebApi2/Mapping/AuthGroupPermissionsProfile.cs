namespace GameWebApi2.Mapping;

public class AuthGroupPermissionsProfile :Profile
{
    public AuthGroupPermissionsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<AuthGroupPermissions, AuthGroupPermissionsViewModel>();
        CreateMap<AuthGroupPermissionsDTO, AuthGroupPermissions>();

        CreateMap<AuthGroupPermissionsAddDTO, AuthGroupPermissions>();


        CreateMap<AuthGroupPermissionsUpdateDTO, AuthGroupPermissions>();
    }
}
