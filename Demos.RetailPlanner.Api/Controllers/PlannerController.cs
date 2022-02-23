using Demos.RetailPlanner.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demos.RetailPlanner.Api.Controllers
{

    //TODO: Secure
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]    
    public class PlannerController : ControllerBase
    {
        //TODO: Secure
        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        //static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        [HttpGet]
        public FiscalYear Get(int year)
        {
            //TODO: Secure
            //HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            var fiscalYear = new FiscalYear(year);
            return fiscalYear;
        }
    }
}
