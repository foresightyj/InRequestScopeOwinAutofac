using InRequestScopeOwinAutofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InRequestScopeOwinAutofac.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        private readonly ICalc _calc;
        private readonly ICalc _calc2;

        public ValuesController(ICalc calc, ICalc calc2)
        {
            _calc = calc;
            _calc2 = calc2;
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var res1 = _calc.Add(id, id);
            var res2 = _calc2.Add(id, id);
            //If InRequestScope works as expected, all ICalc instances here will be the same object, with the same ID (==1).
            //But in fact, in unit test, when using the Self Hosting option, the result is 1 + 2 + 3 == 6
            var res = _calc.Id + _calc2.Id;
            return Ok(res);
        }
    }
}