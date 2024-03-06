namespace GameWebApi2.Mapping;

public class PricesProfile : Profile
{
    public PricesProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<Prices, PricesViewModel>();

        CreateMap<PricesDTO, Prices>();

        CreateMap<PricesAddDTO, Prices>();

        CreateMap<PricesUpdateDTO, Prices>();

    }
}
