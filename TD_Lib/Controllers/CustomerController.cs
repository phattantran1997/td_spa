using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Entity;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace TD_SPA_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly CommonContext commonContext;

        public CustomerController(ICustomerRepository customerRepository, CommonContext commonContext)
        {
            this.commonContext = commonContext;
            this.customerRepository = customerRepository;

        }
        [HttpGet]
        public async Task<IEnumerable<Customer?>> GetAll()
        {
            return await customerRepository.GetAll();
        }
        [HttpGet("{iduser}")]
        public async Task<ActionResult< Customer?>> Get(int iduser)
        {
            var resutl = await customerRepository.GetById(iduser);
            return resutl != null ? resutl : NotFound();
        }


    }
}
