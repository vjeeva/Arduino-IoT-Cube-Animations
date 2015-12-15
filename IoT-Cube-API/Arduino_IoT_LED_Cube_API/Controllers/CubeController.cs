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
        
        public CubeController()
        {
        }

        [HttpGet]
        [Route("SendCommand/{commandInput}")]
        public JObject SendCommand(string commandInput)
        {
            var directory = System.Web.HttpContext.Current.Server.MapPath("/Commands");
            var filepath = Directory.GetFiles(directory, "commands.txt");
            var path = Path.Combine(directory, filepath[0]);
            string text = System.IO.File.ReadAllText(@path).Trim();

            JObject response = new JObject();

            if (text.Trim() == commandInput)
            {
                response["Message"] = "Already executed";
                return response;
            }

            File.WriteAllText(@path, String.Empty);

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@path, true))
            {
                file.WriteLine(commandInput);
            }


            response["Message"] = "OK";
            return response;

            //command["Command"] = commandInput;
            //return HttpStatusCode.OK;
        }

        [HttpGet]
        [Route("GetCommand")]
        public JObject GetCommand()
        {
            var directory = System.Web.HttpContext.Current.Server.MapPath("/Commands");
            var filepath = Directory.GetFiles(directory, "commands.txt");
            var path = Path.Combine(directory, filepath[0]);
            string text = System.IO.File.ReadAllText(@path).Trim();
            JObject response = new JObject();
            response["Command"] = text;
            return response;
        }
    }
}
