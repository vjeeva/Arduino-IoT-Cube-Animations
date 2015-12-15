using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace Arduino_IoT_LED_Cube_API.Controllers
{
    [RoutePrefix("CubeControl")]
    public class CubeController : ApiController
    {
        JObject command;

        public CubeController()
        {
            command = new JObject();
        }

        [HttpGet]
        [Route("SendCommand/{commandInput}")]
        public HttpStatusCode SendCommand(string commandInput)
        {
            var directory = System.Web.HttpContext.Current.Server.MapPath("/Commands");
            var filepath = Directory.GetFiles(directory, "commands.txt");
            var path = Path.Combine(directory, filepath[0]);
            File.WriteAllText(@path, String.Empty);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@path, true))
            {
                file.WriteLine(commandInput);
            }
            return HttpStatusCode.OK;

            //command["Command"] = commandInput;
            //return HttpStatusCode.OK;
        }

        [HttpGet]
        [Route("GetCommand")]
        public JObject GetCommand()
        {
            Console.WriteLine("");
            return command;
        }
    }
}
