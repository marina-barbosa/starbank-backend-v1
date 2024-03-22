using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StarPay.backend.Infra.Services
{
    public class CustomerService
    {
        private readonly CustomerManager<User> _customerManager;
        private readonly IMapper _mapper;

        public CustomerService(CustomerManager<User> customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Register(CustomerCreateDto request)
        {
            var user = _mapper.Map<User>(request);
            var result = await _customerManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}