namespace GameWebApi2.Models;
public class CharItems : BaseEntity //elle değiştirdim i yı
{
        public int id { get; set; }
        public int Category { get; set; }
        public string item { get; set; }
        public int bodyGroup { get; set; }
        public bool isStarterContent { get; set; }
        public int sex { get; set; }
        public bool isSet { get; set; }
        public int groupId { get; set; }
}
