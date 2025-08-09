using Microsoft.Extensions.Configuration;

namespace App.Models.Helpers
{
    public static class ConfigurationHelpers
    {
        public static IConfiguration config;

        public static void TartConfiguration(IConfiguration Configuration)
        {
            config = Configuration;
        }
    }
}
