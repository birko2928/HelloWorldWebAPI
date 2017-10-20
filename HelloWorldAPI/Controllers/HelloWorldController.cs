using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorldAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/HelloWorld/")]
    public class HelloWorldController : ApiController
    {
        Models.Implementations.HelloWorld _hwApp = new Models.Implementations.HelloWorld();

        //// GET api/values
        //[System.Web.Http.Route("{_platform}")]
        //[System.Web.Http.HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { _hwApp.PrintHelloWorld() };
        }

        // GET api/values/5
        public string Get(string id)
        {
            return "";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            //Future implementation for printing recieved values in through the web api.
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public string RecordData(string _value)
        {
            return "The record output is " + _value;
        }
    }
}