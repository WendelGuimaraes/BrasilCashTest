using BrasilCashTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrasilCashTest.Domain.Validations;

namespace BrasilCashTest.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            [HttpPost]
            public void Post([FromBody] Customer1 customer)
            {
                var customerValidation = new CustomerValidation();
                var isValid = customerValidation.Validate(customer);
            }
            [HttpGet]
            public void Get([FromBody] Customer1 customer)
            {
                var customerValidation = new CustomerValidation();
                var isValid = customerValidation.Validate(customer);
            }

        }
    }


