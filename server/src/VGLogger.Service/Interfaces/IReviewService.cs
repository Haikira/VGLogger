using VGLogger.Service.Services.DTOs;

namespace VGLogger.Service.Interfaces
{
    public interface IReviewService
    {
        IList<ReviewDTO> GetReviews();

        ReviewDTO GetReviewById(int id);
    }
}
