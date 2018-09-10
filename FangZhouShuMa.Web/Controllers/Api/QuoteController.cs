using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models.ApiParameters;
using FangZhouShuMa.Web.Models.ApiParameters.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FangZhouShuMa.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Quote")]
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService) => _quoteService = quoteService;

        // GET: api/Quote
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Quote/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Quote
       [HttpPost]
        public IActionResult Post([FromBody]QuoteRequestProductData quoteRequest)
       {
           var quoteResult = _quoteService.Quote(quoteRequest);

            var data = Json(quoteResult);

            return data;
        }

        // POST: api/Quote
        //[HttpPost]
        //public IActionResult Post([FromBody]Person person)
        //{
        //    var data = Json(person);

        //    return data;
        //}

        // PUT: api/Quote/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
