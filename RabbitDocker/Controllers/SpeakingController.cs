using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace RabbitDocker.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpeakingController : ControllerBase
    {
        private const string EnvVar = "REMOTE_ENDPOINT";

        [HttpGet]
        public string Check()
        {
            var variableValue = Environment.GetEnvironmentVariable(EnvVar);
            return variableValue ?? "";
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<string> GetAsync()
        {
            var variableValue = Environment.GetEnvironmentVariable(EnvVar);

            using var client = new HttpClient();

            var numberUri = variableValue + "/generation/getnumber";
            var number = await client.GetStringAsync(numberUri);

            var stringUri = variableValue + "/generation/getstring";
            var @string = await client.GetStringAsync(stringUri);

            return @string + number;
        }

    }
}
