
namespace GameWebApi2.Mapping;

public class GarageProfile : Profile
{
    public GarageProfile()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<Garage, GarageViewModel>(); // İlk yazılan sınıfı ikinci yazılan sınıfa dönüştürür
            //.ForMember(dist => dist.garageName, opt => opt.MapFrom(src => src.garageName.Substring(0,5)));
            //.ReverseMap());
        CreateMap<GarageDTO, Garage>();
        //.ForMember(dist => dist.CreatedDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CreatedDate))); //değişkenleri eşleştirme
        //.ForMember(dist => dist.garageName, opt => opt.MapFrom(src => src.garage_Name)); //değişkenleri eşleştirme
        //mesela virgülden sonra göstemek sitediğimi ayarlayabilir


        CreateMap<GarageAddDTO, Garage>();

        CreateMap<GarageUpdateDTO, Garage>();

    }
}