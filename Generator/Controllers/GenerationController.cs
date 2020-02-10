using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Generator.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenerationController : ControllerBase
    {
        private const string Alpabete = "АБВГДЕЁЖЗИЙКЛМНОРПСТABCDEFGHIJKLMNOPQR";

        [HttpGet]
        public string GetString()
        {
            var rnd = new Random();
            
            var res = "";

            for (int i = 0; i < 10; i++)
            {
                var letterIndex = rnd.Next(0, Alpabete.Length);
                res += Alpabete[letterIndex];
            }

            return res;
        }

        [HttpGet]
        public int GetNumber()
        {
            return new Random().Next(0, 100);
        }
    }
}
