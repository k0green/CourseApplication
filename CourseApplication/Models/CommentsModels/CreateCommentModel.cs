namespace CourseApplication.Models.CommentsModels
{
    public class CreateCommentModel
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public string Comment { get; set; }
    }
}
