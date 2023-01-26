namespace VGLogger.Service.Services.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int StarRating { get; set; }
        public string Description { get; set; }
        public DateTime DateReviewed { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
    }
}
