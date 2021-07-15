using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CleanArch.Api.IntegrationTests.Base;

namespace CleanArch.Api.IntegrationTests.Controllers
{
    public class CategoryControllerTests 
        : IClassFixture<CustomWebApplicationFactors<Startup>>
    {
        private readonly CustomWebApplicationFactors<Startup> _factory;
        public CategoryControllerTests(CustomWebApplicationFactors<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task ReturnSuccessResult()
        {
           // var client = _factory.GetAnonymousClient();
           // var response = client.GetAsync("/api/category/all");

        }
    }
}
