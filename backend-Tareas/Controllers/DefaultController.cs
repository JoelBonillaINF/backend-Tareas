using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_Tareas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
       [HttpGet]
       public string Get()
        {
            return "Aplicacion Corriendo";
        }
    }
}
