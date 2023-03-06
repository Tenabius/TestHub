using TestHub.Core.Entities;

namespace TestHub.Web.ViewModels
{
    public class TestBlankViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public List<QuestionBlankViewModel> QuestionsBlanks { get; }

    }
}
