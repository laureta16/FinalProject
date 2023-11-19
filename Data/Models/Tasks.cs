using FinalProjeckt.Data.Base;

namespace FinalProjeckt.Data.Models
{
    public class Tasks:EntityBase    
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public string Status { get; set; }

    }
}
