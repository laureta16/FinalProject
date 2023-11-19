using FinalProjeckt.Data.Base;

namespace FinalProjeckt.Data.Models
{
    public class Customer:EntityBase
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
