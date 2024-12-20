﻿using ETicaretAPI.Application.Features.Commands.Basket.AddItemToBasket;
using ETicaretAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using ETicaretAPI.Application.Features.Commands.Basket.UpdateQuantity;
using ETicaretAPI.Application.Features.Queries.Basket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController : Controller
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
        {
            List<GetBasketItemsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket([FromBody] AddItemToBasketCommandRequest request)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(request);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateQuantityCommandRequest request)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem ([FromRoute] RemoveBasketItemCommandRequest request)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
