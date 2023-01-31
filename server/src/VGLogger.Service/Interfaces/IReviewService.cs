using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetReviews();
        Task<ReviewDto> GetReviewById(int id);
        void CreateReview(ReviewDto review);
        void DeleteReview(int id);
        void UpdateReview(int id, ReviewDto review);
    }
}
