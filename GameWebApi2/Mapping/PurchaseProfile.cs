namespace GameWebApi2.Mapping;

public class PurchaseProfile : Profile
{
    public PurchaseProfile()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<Purchase, PurchaseViewModel>();

        CreateMap<PurchaseDTO, Purchase>();

        CreateMap<PurchaseAddDTO, Purchase>();

        CreateMap<PurchaseUpdateDTO, Purchase>();

    }
}
