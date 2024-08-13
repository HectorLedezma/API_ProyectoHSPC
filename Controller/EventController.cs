using EventApi.Context;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace EventApi.Controllers
{
    [ApiController]
    [Route("Event")]
    public class EventController : ControllerBase
    {
        
        [HttpGet]
        [Route("GetEvent")]
        public dynamic getEvent(){
            string estado = "";
            try
            {
                estado = "OK";
            }
            catch (System.Exception)
            {
                estado = "error";
            }
            return new {status=estado};
        }

        [HttpPost]
        [Route("SetEvent")]
        public dynamic setEvent(
            [FromBody] Event evento
        ){    
            return new {
                evento
            };
        }
    }
}