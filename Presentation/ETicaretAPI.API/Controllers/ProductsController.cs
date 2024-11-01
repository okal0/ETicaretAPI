using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
    
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
                {
                    new() { Id = Guid.NewGuid(), Name = "Product11", Price = 100, CreatedDate = DateTime.Now, Stock = 15 },
                    new() { Id = Guid.NewGuid(), Name = "Product8", Price = 100, CreatedDate = DateTime.Now, Stock = 15 },
                    new() { Id = Guid.NewGuid(), Name = "Product9", Price = 100, CreatedDate = DateTime.Now, Stock = 15 },
                }
                );
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string Id)
        {
            Product product = await _productReadRepository.GetByIdAsync(Id);

            return Ok(product);
        }
    }
}
