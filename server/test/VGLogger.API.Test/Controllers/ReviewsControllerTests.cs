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

        private ReviewsController RetrieveController()
        {
            return new ReviewsController(_logger, _reviewService, _mapper);
        }
    }
}
