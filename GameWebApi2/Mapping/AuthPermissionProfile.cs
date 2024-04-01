namespace GameWebApi2.Mapping;

public class AuthPermissionProfile :Profile
{
    public AuthPermissionProfile()
    {
        
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<AuthPermission, AuthPermissionViewModel>();
        CreateMap<AuthPermissionDTO, AuthPermission>();

        CreateMap<AuthPermissionAddDTO, AuthPermission>();


        CreateMap<AuthPermissionUpdateDTO, AuthPermission>();
    }
}
