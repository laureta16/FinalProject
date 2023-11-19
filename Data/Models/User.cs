using FinalProjeckt.Data.Base;

namespace FinalProjeckt.Data.Models
{
    public class User:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
