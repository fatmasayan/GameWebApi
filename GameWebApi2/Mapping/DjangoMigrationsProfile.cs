namespace GameWebApi2.Mapping;

public class DjangoMigrationsProfile : Profile
{
    public DjangoMigrationsProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<DjangoMigrations, DjangoMigrationsViewModel>();

        CreateMap<DjangoMigrationsDTO, DjangoMigrations>();

        CreateMap<DjangoMigrationsAddDTO, DjangoMigrations>();

        CreateMap<DjangoMigrationsUpdateDTO, DjangoMigrations>();

    }
}
