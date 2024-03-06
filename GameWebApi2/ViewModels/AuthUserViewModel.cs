namespace GameWebApi2.ViewModels
{
    public class AuthUserViewModel
    {
        public string password { get; set; }
        public DateTime last_login { get; set; }
        public bool is_superuser { get; set; }
        public string username { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public DateTime date_joined { get; set; }
        public string first_name { get; set; }
    }
}
