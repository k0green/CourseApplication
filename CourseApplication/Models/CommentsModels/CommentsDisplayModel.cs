namespace CourseApplication.Models.CommentsModels
{
    public class CommentsDisplayModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ItemId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
