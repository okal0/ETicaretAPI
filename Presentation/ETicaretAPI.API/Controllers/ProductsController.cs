using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using MediatR;
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
        readonly IMediator _mediator;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _mediator = mediator;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        //modelli versiyonlara çevir bunları
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
    }
}
