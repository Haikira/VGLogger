using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using AutoMapper;
using System.Net;
using VGLogger.Service.Services;
using VGLogger.API.ViewModels.Reviews;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : VGLoggerBaseController
{
    private readonly ILogger<ReviewsController> _logger;
    private readonly IMapper _mapper;
    private readonly IReviewService _reviewService;

    public ReviewsController(ILogger<ReviewsController> logger, IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewViewModel createReviewViewModel)
    {
        await _reviewService.CreateReview(_mapper.Map<ReviewDto>(createReviewViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        await _reviewService.DeleteReview(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public ActionResult<ReviewViewModel> GetReviewById(int id)
    {
        var review = _reviewService.GetReviewById(id);

        return Ok(_mapper.Map<ReviewViewModel>(review));
    }

    [HttpGet]
    public ActionResult<IList<ReviewViewModel>> GetReviews()
    {
        var review = _reviewService.GetReviews();

        return OkOrNoContent(_mapper.Map<IList<ReviewViewModel>>(review));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewViewModel updateReviewViewModel)
    {
        await _reviewService.UpdateReview(id, _mapper.Map<ReviewDto>(updateReviewViewModel));

        return NoContent();
    }
}
