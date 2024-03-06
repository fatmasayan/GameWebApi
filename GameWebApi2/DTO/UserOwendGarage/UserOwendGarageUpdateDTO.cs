namespace GameWebApi2.DTO
{
    public class UserOwendGarageUpdateDTO
    {
        public int id { get; set; }
        public bool isActive { get; set; }
        public DateTime createDate { get; set; }
        public int garage_id { get; set; }
        public int loginUser_id { get; set; }
    }
}
