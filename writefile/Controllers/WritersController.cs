using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using writefile.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace writefile.Controllers
{
    [Route("api/[controller]")]
    public class WritersController : Controller
    {
        private string path = "/Users/gie/Desktop/dotnet/";

        // POST api/writers
        [HttpPost("async")]
        public async Task<IActionResult> PostAsync([FromBody] Writer Data)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                await System.IO.File.WriteAllTextAsync(path + Data.Filename, Data.File);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST api/writers
        [HttpPost("sync")]
        public IActionResult PostSync([FromBody] Writer Data)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                System.IO.File.WriteAllText(path + Data.Filename, Data.File);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
