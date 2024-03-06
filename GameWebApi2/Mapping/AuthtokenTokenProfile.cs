namespace GameWebApi2.Mapping;

public class AuthtokenTokenProfile :Profile
{
    public AuthtokenTokenProfile() 
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<AuthtokenToken, AuthtokenTokenViewModel>();

        CreateMap<AuthtokenTokenDTO, AuthtokenToken>();

        CreateMap<AuthtokenTokenAddDTO, AuthtokenToken>();

        CreateMap<AuthtokenTokenUpdateDTO, AuthtokenToken>();

    }
}
