using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Reviews;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using AutoMapper;
using VGLogger.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace VGLogger.Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public ReviewService(IVGLoggerDatabase datebase, IMapper mapper)
        {
            _database = datebase;
            _mapper = mapper;
        }

        public void CreateReview(ReviewDto review)
        {
            throw new NotImplementedException();
        }

        public void DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewDto> GetReviewById(int id)
        {
            var review = await _mapper.ProjectTo<ReviewDto>(_database
                .Get<Review>()
                .Where(new ReviewByIdSpec(id))
                ).SingleOrDefaultAsync();

            return review ?? throw new NotFoundException($"Could not find review with ID: {id}");
        }

        public Task<List<ReviewDto>> GetReviews()
        {
            return _mapper.ProjectTo<ReviewDto>(_database.Get<Review>()).ToListAsync();
        }

        public void UpdateReview(int id, ReviewDto review)
        {
            var existingReview = _database.Get<Review>().FirstOrDefault(new ReviewByIdSpec(id));

            if (existingReview == null) throw new NotFoundException($"Could not find review with ID: {id}");

            _mapper.Map(review, existingReview);

            _database.SaveChanges();
        }
    }
}
