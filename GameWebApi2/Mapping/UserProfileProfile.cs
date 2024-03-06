namespace GameWebApi2.Mapping;

public class UserProfileProfile :Profile
{

    public UserProfileProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<UserProfile, UserProfileViewModel>();

        CreateMap<UserProfileDTO, UserProfile>();

        CreateMap<UserProfileAddDTO, UserProfile>();

        CreateMap<UserProfileUpdateDTO, UserProfile>();

    }
}
