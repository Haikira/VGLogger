using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Profiles;
using VGLogger.Service.Services;

namespace VGLogger.Service.Test.Services
{
    public class ReviewServiceTests
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public ReviewServiceTests()
        {
            _database = Substitute.For<IVGLoggerDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }


        [Fact]
        public async Task GetReview_WhenReviewExists_ReturnsReview()
        {
            // Arrange
            const int id = 1;

            var review = new Review { Id = id };
            var reviews = new List<Review> { review };

            _database.Get<Review>().Returns(reviews.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetReviewById(id);

            // Assert
            result.Should().BeEquivalentTo(review, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetReviews_WhenReviewsExists_ReturnsReviewList()
        {
            // Arrange
            var reviews = _fixture.Build<Review>().CreateMany();

            _database.Get<Review>().Returns(reviews.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetReviews();

            // Assert
            result.Should().BeEquivalentTo(reviews, options => options.ExcludingMissingMembers());
        }

        private IReviewService RetrieveService()
        {
            return new ReviewService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ReviewProfile>();
            });

            return new Mapper(config);
        }
    }
}
