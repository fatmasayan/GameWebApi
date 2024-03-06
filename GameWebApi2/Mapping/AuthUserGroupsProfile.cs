namespace GameWebApi2.Mapping;

public class AuthUserGroupsProfile : Profile
{

    public AuthUserGroupsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<AuthUserGroups, AuthUserGroupsViewModel>();

        CreateMap<AuthUserGroupsDTO, AuthUserGroups>();

        CreateMap<AuthUserGroupsAddDTO, AuthUserGroups>();

        CreateMap<AuthUserGroupsUpdateDTO, AuthUserGroups>();

    }
}
