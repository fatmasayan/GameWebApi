namespace GameWebApi2.Mapping;

public class BikePartsProfile : Profile
{
    public BikePartsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<BikeParts, BikePartsViewModel>();

        CreateMap<BikePartsDTO, BikeParts>();

        CreateMap<BikePartsUpdateDTO, BikeParts>();

        CreateMap<BikePartsAddDTO, BikeParts>();

    }
}
