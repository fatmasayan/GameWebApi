namespace GameWebApi2.Mapping;

public class CharItemsProfile : Profile
{
    public CharItemsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<CharItems, CharItemsViewModel>();

        CreateMap<CharItemsDTO, CharItems>();

        CreateMap<CharItemsAddDTO, CharItems>();

        CreateMap<CharItemsUpdateDTO, CharItems>();

    }
}
