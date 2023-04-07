using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public abstract class QuestionViewModel : IBaseViewModel
    {
        public string? Kind { get; set; }
        public int? QuestionId { get; set; }
        public string? Directions { get; set; }
    }
}
