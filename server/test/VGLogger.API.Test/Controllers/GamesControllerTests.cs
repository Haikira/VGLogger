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
    public class GamesControllerTests
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GamesController> _logger;
        private readonly IMapper _mapper;

        public GamesControllerTests()
        {
            _gameService = Substitute.For<IGameService>();
            _logger = Substitute.For<ILogger<GamesController>>();
            _mapper = Substitute.For<IMapper>();
        }
    }
}
