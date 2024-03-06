namespace GameWebApi2.DTO
{
    public class AuthUserUpdateDTO
    {
        public int id { get; set; }
        public string password { get; set; }
        public DateTime last_login { get; set; }
        public bool is_superuser { get; set; }
        public string username { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public DateTime date_joined { get; set; } //katılma tarihi otomatik alınacak
        public string first_name { get; set; }
    }
}
