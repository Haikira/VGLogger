using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EFCore.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Reviews;
using VGLogger.Service.Dtos;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;

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

        public async Task CreateReview(ReviewDto review)
        {
            var reviewToCreate = _mapper.Map<ReviewDto>(review);
            _database.AddAsync(reviewToCreate);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteReview(int id)
        {
            var reviewToDelete = await _database.Get<Review>().Where(new ReviewByIdSpec(id)).SingleOrDefaultAsync();

            if (reviewToDelete == null) throw new NotFoundException($"Could not find review with id: {id}");

            _database.Delete(reviewToDelete);
            await _database.SaveChangesAsync();
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

        public async Task UpdateReview(int id, ReviewDto review)
        {
            var existingReview = await _database.Get<Review>().FirstOrDefaultAsync(new ReviewByIdSpec(id));

            if (existingReview == null) throw new NotFoundException($"Could not find review with ID: {id}");

            _mapper.Map(review, existingReview);

            await _database.SaveChangesAsync();
        }
    }
}