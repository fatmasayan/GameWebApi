namespace GameWebApi2.Mapping;

public class DjangoSessionProfile : Profile
{
    public DjangoSessionProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<DjangoSession, DjangoSessionViewModel>();

        CreateMap<DjangoSessionDTO, DjangoSession>();

        CreateMap<DjangoSessionAddDTO, DjangoSession>();

        CreateMap<DjangoSessionUpdateDTO, DjangoSession>();

    }
}
