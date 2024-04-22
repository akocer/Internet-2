using uyg04_Work.API.Models;

namespace uyg04_Work.API.DTOs
{
    public class WorkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }
        public int Score { get; set; }
        public int Order { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
