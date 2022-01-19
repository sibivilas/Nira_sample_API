using Nira_SampleProject.Models;
using Nira_SampleProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Nira_SampleProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        Commen_Class Commen_Class = new Commen_Class();

        [Route("api/Login/Login")]
        [HttpPost]
        public IHttpActionResult login(LoginModel model)
        {

            var results = Commen_Class.login(model);
            return Ok(new { results });
        }

        [Route("api/Login/create_Login")]
        [HttpPost]
        public IHttpActionResult create_Login(LoginModel model)
        {

            var results = Commen_Class.create_Login(model);
            return Ok(new { results });
        }
    }
}
