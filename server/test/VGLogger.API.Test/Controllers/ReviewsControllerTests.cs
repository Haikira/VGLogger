using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using VGLogger.Api.Test.Extensions;
using VGLogger.API.Controllers;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Services;

namespace VGLogger.API.Test.Controllers
{
    public class ReviewsControllerTests
    {
        private IReviewService _reviewService;
        private readonly ILogger<ReviewsController> _logger;
        private readonly IMapper _mapper;

        public ReviewsControllerTests()
        {
            _logger = Substitute.For<ILogger<ReviewsController>>();
            _mapper = Substitute.For<IMapper>();
            _reviewService = Substitute.For<IReviewService>();
        }

        [Fact]
        public async Task GetReviews_WhenReviewsExist_MapsAndReturns()
        {
            // Arrange
            var reviewDTOs = new List<ReviewDto>() { new ReviewDto() };
            var reviewViewModels = new List<ReviewViewModel>() { new ReviewViewModel() };
            var controller = RetrieveController();

            _reviewService.GetReviews().Returns(reviewDTOs);
            _mapper.Map<List<ReviewViewModel>>(reviewDTOs).Returns(reviewViewModels);

            // Act
            var actionResult = await controller.GetReviews();

            // Assert
            var result = actionResult.AssertObjectResult<IList<ReviewViewModel>, OkObjectResult>();

            result.Should().BeSameAs(reviewViewModels);

            await _reviewService.Received(1).GetReviews();

            _mapper.Received(1).Map<List<ReviewViewModel>>(reviewDTOs);
        }

        [Fact]
        public async Task GetReviews_WhenNoReviewsExist_ReturnsNoContent()
        {
            // Arrange
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetReviews();

            // Assert
            actionResult.AssertResult<IList<ReviewViewModel>, NoContentResult>();
        }

        private ReviewsController RetrieveController()
        {
            return new ReviewsController(_logger, _reviewService, _mapper);
        }
    }
}
