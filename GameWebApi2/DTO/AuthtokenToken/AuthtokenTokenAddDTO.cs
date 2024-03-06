using System.ComponentModel.DataAnnotations;

namespace GameWebApi2.DTO
{
    public class AuthtokenTokenAddDTO
    {
        public DateTime created { get; set; }
        public int user_id { get; set; }

    }
}
