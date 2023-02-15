using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGLogger.API.Integration.Test.Controllers
{
    public class ReviewControllerTests
    {
        private readonly HttpClient _httpClient;

        public ReviewControllerTests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
