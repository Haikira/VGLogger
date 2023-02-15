using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGLogger.API.Integration.Test.Controllers
{
    public class DeveloperControllerTests
    {
        private readonly HttpClient _httpClient;

        public DeveloperControllerTests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
