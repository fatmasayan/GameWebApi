namespace GameWebApi2.Mapping;

public class AuthUserAndUserPermissionsProfile :Profile
{
    public AuthUserAndUserPermissionsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<AuthUserAndUserPermissions, AuthUserAndUserPermissionsViewModel>();
        CreateMap<AuthUserAndUserPermissionsDTO, AuthUserAndUserPermissions>();

        CreateMap<AuthUserAndUserPermissionsAddDTO, AuthUserAndUserPermissions>();

        CreateMap<AuthUserAndUserPermissionsUpdateDTO, AuthUserAndUserPermissions>();
    }

    
}
