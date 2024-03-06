namespace GameWebApi2.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMaps();
        }
        private void CreateMaps()
        {
            CreateMap<Map, MapViewModel>(); 

            CreateMap<MapDTO, Map>();

            CreateMap<MapAddDTO, Map>();

            CreateMap<MapUpdateDTO, Map>();

        }
    }
}
