using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using AutoMapper;
using System.Net;
using VGLogger.Service.Services;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : VGLoggerBaseController
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

    //[HttpPost]
    //public async Task<IActionResult> CreateDeveloper([FromBody] CreateDeveloperViewModel createDeveloperViewModel)
    //{
    //    await _reviewService.CreateDeveloper(_mapper.Map<DeveloperDto>(createDeveloperViewModel));

    //    return StatusCode((int)HttpStatusCode.Created);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateDeveloper(int id, [FromBody] UpdateDeveloperViewModel updateDeveloperViewModel)
    //{
    //    await _reviewService.UpdateDeveloper(id, _mapper.Map<DeveloperDto>(updateDeveloperViewModel));

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteDeveloper(int id)
    //{
    //    await _reviewService.DeleteReview(id);

    //    return NoContent();
    //}
}
