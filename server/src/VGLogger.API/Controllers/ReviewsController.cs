using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using AutoMapper;
using System.Net;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly ILogger<ReviewsController> _logger;
    private readonly IMapper _mapper;

    public ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _logger = logger;
        _mapper = mapper;
    }
}
