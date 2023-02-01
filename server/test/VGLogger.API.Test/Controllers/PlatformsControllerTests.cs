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

namespace VGLogger.API.Test.Controllers
{
    public class PlatformsControllerTests
    {
        private readonly ILogger<PlatformsController> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatformService _platformService;

        public PlatformsControllerTests()
        {
            _logger = Substitute.For<ILogger<PlatformsController>>();
            _mapper = Substitute.For<IMapper>();
            _platformService = Substitute.For<IPlatformService>();
        }
    }
}
