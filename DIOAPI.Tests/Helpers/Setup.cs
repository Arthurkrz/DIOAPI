using DIOAPI.Dominio.Interfaces;
using DIOAPI.Dominio.Servicos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace DIOAPI.Tests.Helpers
{
    public class Setup
    {
        public const string PORT = "5001";
        public static TestContext testContext = default!;
        public static WebApplicationFactory<Startup> Http = default!;
        public static HttpClient Client = default!;

        public static void ClassCleanup() => Setup.Http.Dispose();

        public static void ClassInit(TestContext testContext)
        {
            Setup.testContext = testContext;
            Setup.Http = new WebApplicationFactory<Startup>();

            Setup.Http = Setup.Http.WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

                builder.ConfigureServices(services =>
                { services.AddScoped<IAdministradorServico, AdministradorServico>(); });
            });
        }
    }
}
