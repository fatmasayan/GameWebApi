namespace GameWebApi2.Mapping;

public class DjangoContentTypeProfile : Profile
{

    public DjangoContentTypeProfile()
    {
        CreateMaps();
    }
    private void CreateMaps()
    {
        CreateMap<DjangoContentType, DjangoContentTypeViewModel>();

        CreateMap<DjangoContentTypeDTO, DjangoContentType>();

        CreateMap<DjangoContentTypeAddDTO, DjangoContentType>();

        CreateMap<DjangoContentTypeUpdateDTO, DjangoContentType>();

    }
}
