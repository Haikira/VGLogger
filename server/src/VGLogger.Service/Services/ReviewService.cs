using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Reviews;
using VGLogger.Service.Interfaces;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IVGLoggerDatabase _database;

        public ReviewService(IVGLoggerDatabase datebase)
        {
            _database = datebase;
        }

        public IList<ReviewDTO> GetReviews()
        {
            var reviews = _database.Get<Review>().ToList();

            return reviews
                .Select(x => new ReviewDTO 
                { 
                    DateReviewed = x.DateReviewed, 
                    Description = x.Description, 
                    GameId = x.GameId, 
                    Id = x.Id, 
                    StarRating = x.StarRating, 
                    UserId = x.UserId 
                })
                .ToList();
        }

        public ReviewDTO GetReviewById(int id)
        {
            var review = _database.Get<Review>().Where(new ReviewByIdSpec(id)).SingleOrDefault();

            return new ReviewDTO 
            {
                DateReviewed = review.DateReviewed,
                Description = review.Description,
                GameId = review.GameId,
                Id = review.Id,
                StarRating = review.StarRating,
                UserId = review.UserId
            };
        }
    }
}
