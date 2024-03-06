namespace GameWebApi2.Mapping;

public class DjangoAdminLogProfile : Profile
{
    public DjangoAdminLogProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<DjangoAdminLog, DjangoAdminLogViewModel>();

        CreateMap<DjangoAdminLogDTO, DjangoAdminLog>();

        CreateMap<DjangoAdminLogAddDTO, DjangoAdminLog>();

        CreateMap<DjangoAdminLogUpdateDTO, DjangoAdminLog>();

    }
}
