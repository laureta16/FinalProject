using FinalProjeckt.Data.Base;

namespace FinalProjeckt.Data.Models
{
    public class Project:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
