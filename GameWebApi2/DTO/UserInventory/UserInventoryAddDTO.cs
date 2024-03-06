namespace GameWebApi2.DTO
{
    public class UserInventoryAddDTO
    {
        //public int id { get; set; }
        public int tokenPremium { get; set; }
        public int tokenInGame { get; set; }
        public int tokenOfAvatar { get; set; }
        public double totalKM { get; set; }
        public DateTime date { get; set; }
        public int loginUser_id { get; set; }
    }
}
