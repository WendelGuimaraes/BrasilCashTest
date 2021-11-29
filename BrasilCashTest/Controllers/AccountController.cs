using BrasilCashTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BrasilCashTest.Domain.Validations;
using BrasilCashTest.Context;
using FluentValidation;
using BrasilCashTest.ViewModels;
using System.Linq;
using BrasilCashTest.Repositories;
using BrasilCashTest.Services;

namespace BrasilCashTest.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {
            var customer = new Customer(customerViewModel.name, customerViewModel.taxId,
                customerViewModel.password, customerViewModel.phoneNumber, customerViewModel.postalCode);

            var customerValidation = new CustomerValidation();
            var isValid = customerValidation.Validate(customer);

            if (!isValid.IsValid)
                return new BadRequestObjectResult(string.Join(',', isValid.Errors.Select(x => x.ErrorMessage)));

            if (!string.IsNullOrEmpty(customer.PostalCode))
            {
                var address = RestService.Get<Address>(@"https://viacep.com.br", $"ws/{customer.PostalCode}/json");
                customer.setAddress(address);
            }

            var customerRepository = new CustomerRepository(_context);

            var customerSaved = customerRepository.Save(customer);

            return new JsonResult(customerSaved);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string name, [FromQuery] string taxId, [FromQuery] DateTime? createdAt)
        {
            var customerRepository = new CustomerRepository(_context);

            var customer = customerRepository.GetAll(name, taxId, createdAt);

            if (!customer.Any())
                return new NoContentResult();

            return new JsonResult(customer);
        }
    }
}


