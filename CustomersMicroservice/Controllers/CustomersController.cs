using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext context;



        public CustomersController(CustomerContext ctx)
        {
            this.context = ctx;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetCustomers()
        {
            var query = from item in context.Customers
                        select item;
            var result = await query.ToListAsync();
            return Ok(result);
        }







        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> SaveCustomer(Customer obj)
        {
            context.Customers.Add(obj);
            await context.SaveChangesAsync();
            return StatusCode(201);
        }

    }

    public class PropertiesController : ControllerBase
    {
        private readonly CustomerContext context;



        public PropertiesController(CustomerContext ctx)
        {
            this.context = ctx;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Property>))]
        [Route("/GetProperties")]
        public async Task<IActionResult> GetProperties()
        {
            List<Property> properties = new List<Property>();
            string apiurl = "http://localhost:44388/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Property");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    properties = JsonConvert.DeserializeObject<List<Property>>(json);
                }
            }
            return Ok(properties);
        }

        

    }

}
    