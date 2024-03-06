namespace GameWebApi2.DTO
{
    public class MapUpdateDTO
    {
        public int id { get; set; }
        public string mapName { get; set; }
        public int totalKM { get; set; }
        public int difficulty { get; set; }
        public int maxSlope { get; set; }
        public double slopeLength { get; set; }
        public double averageTime { get; set; }
        public int alternateRoute { get; set; }
        public int viewPoint { get; set; }
        public bool casual { get; set; }
        public bool competetive { get; set; }
    }
}
