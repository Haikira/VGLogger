namespace VGLogger.API.ViewModels
{
    public class CreateReviewViewModel
    {
        public int StarRating { get; set; }
        public string Description { get; set; }
        public DateTime DateReviewed { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
    }
}
