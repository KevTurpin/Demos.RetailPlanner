using Demos.RetailPlanner.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demos.RetailPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailPlannerController : ControllerBase
    {
        [HttpGet]
        public FiscalYear Get(int year)
        {
            var fiscalYear = new FiscalYear(year);

            return fiscalYear;
        }
    }
}
