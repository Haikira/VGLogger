using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetReviews();
        Task<ReviewDto> GetReviewById(int id);
        Task CreateReview(ReviewDto review);
        Task DeleteReview(int id);
        Task UpdateReview(int id, ReviewDto review);
    }
}
