using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Api.IntegrationTests.Base
{
    public class CustomWebApplicationFactors<TStartup>
        :WebApplicationFactory<TStartup> where TStartup : class
    {
    }
}
